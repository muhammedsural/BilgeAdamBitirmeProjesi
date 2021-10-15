create table BillingAddress
(
    id                         int          not null
        primary key,
    firstname                  varchar(255) not null,
    surname                    varchar(255) not null,
    country                    varchar(128) not null,
    location                   varchar(128) not null,
    subLocation                varchar(128),
    address                    varchar      not null,
    phonenumber                varchar(32),
    mobilePhonenumber          varchar(32)  not null,
    orderId                    int          not null,
    invoiceType                varchar(10)  not null,
    taxNo                      int          not null,
    taxOffice                  varchar(255) not null,
    identityRegistrationnumber int          not null
)
go

create table Brand
(
    id                     int          not null
        primary key,
    name                   varchar(255) not null,
    slug                   varchar(255),
    sortOrder              int,
    status                 bit          not null,
    distributorCode        varchar(255),
    distributor            varchar(255),
    imageFile              varchar(255),
    showcaseContent        varchar,
    displayShowcaseContent bit,
    metaKeywords           varchar,
    metaDescription        varchar,
    pageTitle              varchar(255),
    createdAt              datetime,
    updatedAt              datetime
)
go

create table Category
(
    id                         int          not null
        primary key,
    name                       varchar(255) not null,
    slug                       varchar(255),
    sortOrder                  int,
    status                     bit          not null,
    distributorCode            varchar(255),
    [percent]                  int,
    imageFile                  varchar(255),
    distributor                varchar(128),
    displayShowcaseContent     int,
    showcaseContent            varchar,
    showcaseContentDisplayType int          not null,
    hasChildren                varchar,
    metaKeywords               varchar,
    metaDescription            varchar,
    pageTitle                  varchar,
    parentId                   int          not null
        constraint FK_Category_Category
            references Category,
    createdAt                  datetime,
    updatedAt                  datetime
)
go

create table Country
(
    id     int          not null
        primary key,
    name   varchar(255) not null,
    status bit          not null
)
go

create table Currency
(
    id           int         not null
        primary key,
    label        varchar(50) not null,
    buyingPrice  numeric,
    sellingPrice numeric,
    abbr         varchar(5),
    updatedAt    datetime,
    status       bit,
    isPrimary    bit
)
go

create table Label
(
    id              int          not null
        primary key,
    name            varchar(255) not null,
    sortOrder       int,
    hasChildren     bit,
    slug            varchar(255),
    metaTitle       varchar(255),
    metaKeywords    varchar(255),
    metaDescription varchar(255),
    status          bit          not null,
    createdAt       datetime,
    updatedAt       datetime,
    parentId        int          not null
        constraint FK_Label_Label
            references Label
)
go



create table MemberGroup
(
    id                     int          not null
        primary key,
    name                   varchar(255) not null,
    priceIndex             int          not null,
    allowedPaymentGateways varchar(512) not null
)
go

create table OptionGroup
(
    id           int          not null
        primary key,
    title        varchar(255) not null,
    slug         varchar      not null,
    sortOrder    int          not null,
    filterStatus bit          not null
)
go

create table Options
(
    id            int          not null
        primary key,
    title         varchar(255) not null,
    slug          varchar(255),
    sortOrder     int,
    logo          varchar,
    optionGroupId int          not null
        constraint FK_Options_OptionGroup
            references OptionGroup
)
go



create table Product
(
    id                     int          not null
        primary key,
    name                   varchar(255) not null,
    slug                   varchar,
    fullName               varchar(255) not null,
    sku                    varchar(255) not null,
    barcode                int,
    price1                 numeric      not null,
    warranty               int,
    tax                    int,
    stockAmount            numeric,
    volumetricWeight       numeric,
    buyingPrice            numeric,
    stockTypeLabel         varchar,
    discount               numeric,
    discountType           int,
    moneyOrderDiscount     numeric,
    status                 bit          not null,
    taxIncluded            bit,
    distributor            varchar(255),
    isGifted               bit,
    gift                   varchar(255),
    customShippingDisabled bit          not null,
    customShippingCost     numeric,
    marketPriceDetail      varchar(255) not null,
    createdAt              datetime,
    updatedAt              datetime,
    metaKeywords           varchar      not null,
    metaDescription        varchar      not null,
    pageTitle              varchar(255) not null,
    hasOption              bit          not null,
    shortDetails           varchar(512) not null,
    searchKeywords         varchar(255) not null,
    installmentThreshold   varchar(10)  not null,
    homeSortOrder          int,
    popularSortOrder       int,
    brandSortOrder         int,
    featuredSortOrder      int,
    campaignedSortOrder    int,
    newSortOrder           int,
    discountedSortOrder    int,
    brandId                int          not null
        constraint FK_Product_Brand
            references Brand,
    currencyId             int          not null
        constraint FK_Product_Currency
            references Currency,
    parentId               int          not null
        constraint FK_Product_Product
            references Product,
    countdownId            int          not null,
    pricesId               int          not null,
    imagesId               int          not null,
    productToCategoriesId  int          not null
)
go

create table CartItem
(
    id              int      not null
        primary key,
    parentProductId int,
    quantity        numeric  not null,
    categoryId      int,
    createdAt       datetime,
    updatedAt       datetime not null,
    cartId          int      not null,
    productId       int      not null
        constraint FK_CartItem_Product
            references Product,
    attributesId    int
)
go

create table LabelToProduct
(
    id        int not null
        primary key,
    labelId   int not null
        constraint FK_LabelToProduct_Label
            references Label,
    productId int not null
        constraint FK_LabelToProduct_Product
            references Product
)
go

create table OptionToProduct
(
    id              int not null
        primary key,
    parentProductId int not null,
    optionGroupId   int not null
        constraint FK_OptionToProduct_OptionGroup
            references OptionGroup,
    optionId        int not null
        constraint FK_OptionToProduct_Options
            references Options,
    productId       int not null
        constraint FK_OptionToProduct_Product
            references Product
)
go

create table ProductButton
(
    id                int not null
        primary key,
    fastShipping      bit,
    sameDayShipping   bit,
    threeDaysDelivery bit,
    fiveDaysDelivery  bit,
    sevenDaysDelivery bit,
    freeShipping      bit,
    deliveryFromStock bit,
    preOrderedProduct bit,
    limitedStock      bit,
    askStock          bit,
    campaignedProduct bit,
    productId         int not null
        constraint FK_ProductButton_Product
            references Product
)
go

create table ProductDetail
(
    id           int          not null
        primary key,
    sku          varchar(255) not null,
    details      varchar      not null,
    extraDetails varchar      not null,
    productId    int          not null
        constraint FK_ProductDetail_Product
            references Product
)
go

create table ProductImage
(
    id            int          not null
        primary key,
    filename      varchar(255) not null,
    extension     varchar      not null,
    directoryName int,
    revision      int,
    sortOrder     int          not null,
    productId     int          not null
        constraint FK_ProductImage_Product
            references Product,
    attachment    varchar      not null
)
go

alter table Product
    add constraint FK_Product_ProductImage
        foreign key (imagesId) references ProductImage
go

create table ProductPrice
(
    id        int     not null
        primary key,
    value     numeric not null,
    type      int     not null,
    productId int     not null
        constraint FK_ProductPrice_Product
            references Product
)
go

alter table Product
    add constraint FK_Product_ProductPrice
        foreign key (pricesId) references ProductPrice
go

create table ProductProtection
(
    id               int not null
        primary key,
    isPriceProtected bit not null,
    isStockProtected bit not null,
    productid        int not null
        constraint FK_ProductProtection_Product
            references Product
)
go

create table ProductSpecialInfo
(
    id        int          not null
        primary key,
    title     varchar(255) not null,
    content   varchar      not null,
    status    bit          not null,
    productid int          not null
        constraint FK_ProductSpecialInfo_Product
            references Product
)
go

create table ProductToCategory
(
    id         int not null
        primary key,
    sortOrder  int,
    productId  int not null
        constraint FK_ProductToCategory_Product
            references Product,
    categoryId int not null
        constraint FK_ProductToCategory_Category
            references Category
)
go

alter table Product
    add constraint FK_Product_ProductToCategory
        foreign key (productToCategoriesId) references ProductToCategory
go

create table ProductToCountDown
(
    id           int not null
        primary key,
    startDate    datetime,
    endDate      datetime,
    expireDate   datetime,
    useCountDown bit not null,
    productId    int not null
        constraint FK_ProductToCountDown_Product
            references Product
)
go

alter table Product
    add constraint FK_Product_ProductToCountDown
        foreign key (countdownId) references ProductToCountDown
go

create table PurchaseLimitation
(
    id           int          not null
        primary key,
    name         varchar(255) not null,
    minimumLimit numeric,
    maximumLimit numeric,
    type         varchar      not null,
    status       bit
)
go

create table PurchaseLimitationItem
(
    id            int not null
        primary key,
    brandId       int not null
        constraint FK_PurchaseLimitationItem_Brand
            references Brand,
    categoryId    int not null
        constraint FK_PurchaseLimitationItem_Category
            references Category,
    limitationId  int not null
        constraint FK_PurchaseLimitationItem_PurchaseLimitation
            references PurchaseLimitation,
    memberGroupId int not null
        constraint FK_PurchaseLimitationItem_MemberGroup
            references MemberGroup,
    productId     int not null
        constraint FK_PurchaseLimitationItem_Product
            references Product
)
go



create table Location
(
    id         int          not null
        primary key,
    name       varchar(255) not null,
    status     bit          not null,
    predefined bit,
    countryid  int          not null
        constraint FK_Location_Country
            references Country,

)
go

create table Member
(
    id                              int          not null
        primary key,
    firstname                       varchar(255) not null,
    surname                         varchar(255) not null,
    email                           varchar(255) not null,
    gender                          varchar,
    birthDate                       datetime,
    phonenumber                     varchar(255),
    mobilePhonenumber               varchar(255),
    otherLocation                   varchar(255),
    address                         varchar,
    taxnumeric                      int,
    tcId                            int,
    status                          varchar,
    lastLoginDate                   datetime,
    createdAt                       datetime,
    updatedAt                       datetime,
    zipCode                         int,
    commercialName                  varchar(255),
    taxOffice                       varchar(255),
    lastMailSentDate                datetime,
    lastIp                          varchar(255),
    gainedPointAmount               numeric,
    spentPointAmount                numeric,
    allowedToCampaigns              bit,
    referredMemberGainedPointAmount numeric,
    district                        varchar(255),
    deviceType                      varchar(255) not null,
    deviceInfo                      varchar,
    countryId                       int          not null
        constraint FK_Member_Country
            references Country,
    locationId                      int          not null
        constraint FK_Member_Location
            references Location,
    memberGroupId                   int          not null
        constraint FK_Member_MemberGroup
            references MemberGroup,
    referredMemberId                int          not null
        constraint FK_Member_Member
            references Member
)
go

create table CurrentAccount
(
    id        int          not null
        primary key,
    code      varchar(255),
    title     varchar(255) not null,
    balance   numeric,
    riskLimit numeric,
    createdAt datetime,
    updatedAt datetime,
    memberId  int          not null
        constraint FK_CurrentAccount_Member
            references Member
)
go

create table FavouritedProduct
(
    id        int not null
        primary key,
    memberId  int not null
        constraint FK_FavouritedProduct_Member
            references Member,
    productId int not null
        constraint FK_FavouritedProduct_Product
            references Product
)
go

create table [Order]
(
    id                      int          not null
        primary key,
    customerFirstname       varchar(255) not null,
    customerSurname         varchar(255) not null,
    customerEmail           varchar(255) not null,
    customerPhone           varchar(32),
    paymentTypeName         varchar(128) not null,
    paymentProviderCode     varchar(128) not null,
    paymentProviderName     varchar(128) not null,
    paymentGatewayCode      varchar(128) not null,
    paymentGatewayName      varchar(128) not null,
    bankName                varchar(128),
    clientIp                varchar(32)  not null,
    userAgent               varchar(1024),
    currency                varchar(32)  not null,
    currencyRates           varchar(255) not null,
    amount                  numeric      not null,
    couponDiscount          numeric      not null,
    taxAmount               numeric      not null,
    promotionDiscount       numeric      not null,
    generalAmount           numeric      not null,
    shippingAmount          numeric      not null,
    additionalServiceAmount numeric      not null,
    finalAmount             numeric      not null,
    sumOfGainedPoints       numeric,
    installment             int,
    installmentRate         numeric,
    extraInstallment        int,
    transactionId           varchar(255),
    hasUserNote             bit,
    status                  varchar      not null,
    paymentStatus           varchar      not null,
    errorMessage            varchar,
    deviceType              varchar      not null,
    referrer                varchar,
    invoicePrintCount       int,
    useGiftPackage          bit,
    giftNote                varchar,
    memberGroupName         varchar(255),
    usePromotion            bit,
    shippingProviderCode    varchar(128),
    shippingProviderName    varchar(128),
    shippingCompanyName     varchar(128),
    shippingPaymentType     varchar,
    shippingTrackingCode    varchar(255),
    source                  varchar(255) not null,
    createdAt               datetime,
    updatedAt               datetime,
    memberId                int          not null
        constraint FK_Order_Member
            references Member,
    orderDetailsId          int          not null,
    orderItemsId            int          not null,
    shippingAddressId       int          not null,
    billingAddressId        int          not null
        constraint FK_Order_BillingAddress
            references BillingAddress
)
go

alter table BillingAddress
    add constraint FK_BillingAddress_Order
        foreign key (orderId) references [Order]
go

create table OrderAddress
(
    id                int          not null
        primary key,
    firstname         varchar(255) not null,
    surname           varchar(255) not null,
    country           varchar(128) not null,
    location          varchar(128) not null,
    subLocation       varchar(128),
    address           varchar      not null,
    phonenumber       varchar(32),
    mobilePhonenumber varchar(32)  not null,
    orderId           int          not null
        constraint FK_OrderAddress_Order
            references [Order]
)
go

create table OrderDetail
(
    id       int          not null
        primary key,
    varKey   varchar(255) not null,
    varValue varchar      not null,
    orderId  int          not null
        constraint FK_OrderDetail_Order
            references [Order]
)
go

alter table [Order]
    add constraint FK_Order_OrderDetail
        foreign key (orderDetailsId) references OrderDetail
go

create table OrderItem
(
    id                        int          not null
        primary key,
    productName               varchar(255) not null,
    productSku                varchar(255) not null,
    productBarcode            int,
    productPrice              numeric      not null,
    productCurrency           varchar(32)  not null,
    productQuantity           numeric      not null,
    productTax                int          not null,
    productDiscount           numeric      not null,
    productMoneyOrderDiscount numeric      not null,
    productWeight             numeric      not null,
    productStockTypeLabel     varchar(255) not null,
    isProductPromotioned      bit,
    discount                  numeric      not null,
    orderId                   int          not null
        constraint FK_OrderItem_Order
            references [Order],
    productId                 int          not null
        constraint FK_OrderItem_Product
            references Product,

)
go

alter table [Order]
    add constraint FK_Order_OrderItem
        foreign key (orderItemsId) references OrderItem
go

create table OrderRefundRequest
(
    id                 int          not null
        primary key,
    code               varchar(255) not null,
    status             varchar      not null,
    fee                numeric      not null,
    cancellationReason varchar(512),
    createdAt          datetime,
    updatedAt          datetime,
    memberId           int          not null
        constraint FK_OrderRefundRequest_Member
            references Member,
    orderId            int          not null
        constraint FK_OrderRefundRequest_Order
            references [Order]
)
go

create table OrderRefundRequestItem
(
    id                   int           not null
        primary key,
    amount               numeric       not null,
    reason               varchar(1024) not null,
    details              varchar       not null,
    createdAt            datetime,
    updatedAt            datetime,
    orderItemId          int           not null
        constraint FK_OrderRefundRequestItem_OrderItem
            references OrderItem,
    orderRefundRequestId int           not null
        constraint FK_OrderRefundRequestItem_OrderRefundRequest
            references OrderRefundRequest
)
go

create table OrderUserNote
(
    id            int          not null
        primary key,
    userEmail     varchar(255) not null,
    userFirstname varchar(255),
    userSurname   varchar(255),
    note          varchar,
    createdAt     datetime,
    updatedAt     datetime,
    orderId       int          not null
        constraint FK_OrderUserNote_Order
            references [Order]
)
go

create table Payment
(
    id                  int          not null
        primary key,
    memberFirstname     varchar(255) not null,
    memberSurname       varchar(255) not null,
    memberEmail         varchar(255) not null,
    memberPhone         varchar(255),
    paymentTypeName     varchar(128) not null,
    paymentProviderCode varchar(64)  not null,
    paymentProviderName varchar(128) not null,
    paymentGatewayName  varchar(128) not null,
    paymentGatewayCode  varchar(128) not null,
    bankName            varchar(64),
    deviceType          varchar      not null,
    clientIp            varchar(32)  not null,
    currencyRates       varchar(255) not null,
    amount              numeric      not null,
    finalAmount         numeric      not null,
    sumOfGainedPoints   numeric,
    installment         numeric      not null,
    installmentRate     numeric      not null,
    extraInstallment    int,
    currency            varchar(12)  not null,
    transactionId       int,
    memberNote          varchar,
    userNote            varchar,
    status              varchar      not null,
    errorMessage        varchar,
    cardSavingSystem    varchar(255),
    createdAt           datetime,
    memberid            int          not null
        constraint FK_Payment_Member
            references Member
)
go

create table ProductComment
(
    id          int          not null
        primary key,
    title       varchar(255) not null,
    content     varchar      not null,
    status      bit          not null,
    rank        int          not null,
    isAnonymous bit          not null,
    createdAt   datetime,
    updatedAt   datetime,
    memberId    int          not null
        constraint FK_ProductComment_Member
            references Member,
    productId   int          not null
        constraint FK_ProductComment_Product
            references Product
)
go


create table Shipment
(
    id              int not null
        primary key,
    barcode         varchar(255),
    waybillNo       varchar(255),
    invoiceKey      varchar(255),
    cargoOffice     varchar(255),
    code            varchar(255),
    deliveryType    varchar(255),
    invoiceIncluded bit,
    payAtDoorAmount numeric,
    createdAt       datetime,
    status          bit not null,
    orderId         int
        constraint FK_Shipment_Order
            references [Order],
    barcodeImage    varchar,
    trackingUrl     varchar(255)
)
go

create table ShipmentItem
(
    id            int      not null
        primary key,
    rootProductId int,
    amount        int      not null,
    price         numeric  not null,
    productLabel  varchar(255),
    currency      varchar  not null,
    tax           int,
    dm3           numeric  not null,
    createdAt     datetime,
    status        bit      not null,
    updatedAt     datetime not null,
    orderItemId   int      not null
        constraint FK_ShipmentItem_OrderItem
            references OrderItem,
    productId     int      not null
        constraint FK_ShipmentItem_Product
            references Product,
    shipmentId    int      not null
        constraint FK_ShipmentItem_Shipment
            references Shipment
)
go

create table ShippingAddress
(
    id                int          not null
        primary key,
    firstname         varchar(255) not null,
    surname           varchar(255) not null,
    country           varchar(128) not null,
    location          varchar(128) not null,
    subLocation       varchar(128) not null,
    address           varchar      not null,
    phonenumber       varchar(32),
    mobilePhonenumber varchar(32),
    orderId           int          not null
        constraint FK_ShippingAddress_Order
            references [Order]
)
go

alter table [Order]
    add constraint FK_Order_ShippingAddress
        foreign key (shippingAddressId) references ShippingAddress
go

create table ShopCampaigns
(
    id    int not null
        primary key,
    label varchar(255)
)
go

create table ShopTokens
(
    id   int not null
        primary key,
    code varchar(255)
)
go

create table Cart
(
    id                int          not null
        primary key,
    sessionId         varchar(255) not null,
    locked            bit,
    createdAt         datetime,
    updatedAt         datetime,
    chosenPromotionId int          not null
        constraint FK_Cart_ShopCampaigns
            references ShopCampaigns,
    memberId          int          not null
        constraint FK_Cart_Member
            references Member,
    chosenTokenId     int          not null
        constraint FK_Cart_ShopTokens
            references ShopTokens,
    itemsId           int          not null
        constraint FK_Cart_CartItem
            references CartItem
)
go

create table ShopUserlevels
(
    id    int not null
        primary key,
    label varchar,
    roles varchar
)
go

create table SpecGroup
(
    id        int          not null
        primary key,
    name      varchar(255) not null,
    sortOrder int,
    status    bit          not null
)
go

create table SpecName
(
    id          int          not null
        primary key,
    name        varchar(255) not null,
    slug        varchar(255),
    choiceType  varchar      not null,
    sortOrder   int,
    status      bit          not null,
    specGroupId int          not null
        constraint FK_SpecName_SpecGroup
            references SpecGroup
)
go

create table SpecValue
(
    id          int          not null
        primary key,
    name        varchar(255) not null,
    slug        varchar(255),
    sortOrder   int,
    logo        varchar,
    status      bit          not null,
    specGroupId int          not null
        constraint FK_SpecValue_SpecGroup
            references SpecGroup,
    specNameId  int          not null
        constraint FK_SpecValue_SpecName
            references SpecName
)
go

create table SpecToProduct
(
    id          int not null
        primary key,
    productId   int not null
        constraint FK_SpecToProduct_Product
            references Product,
    specGroupId int not null
        constraint FK_SpecToProduct_SpecGroup
            references SpecGroup,
    specNameId  int not null
        constraint FK_SpecToProduct_SpecName
            references SpecName,
    specValueId int not null
        constraint FK_SpecToProduct_SpecValue
            references SpecValue
)
go

create table Tag
(
    id              int          not null
        primary key,
    name            varchar(255) not null,
    count           int,
    pageTitle       varchar,
    metaDescription varchar,
    metaKeywords    varchar
)
go

create table ProductToTag
(
    id        int not null
        primary key,
    productId int not null
        constraint FK_ProductToTag_Product
            references Product,
    tagId     int not null
        constraint FK_ProductToTag_Tag
            references Tag
)
go



create table MemberAddress
(
    id                int not null
        primary key,
    name              varchar(255),
    type              varchar(20),
    firstname         varchar(255),
    surname           varchar(255),
    address           varchar,
    subLocationName   varchar(255),
    phonenumber       varchar(32),
    mobilePhonenumber varchar(32),
    tcId              int,
    taxnumeric        int,
    taxOffice         varchar(255),
    invoiceType       varchar(255),
    isEinvoiceUser    bit,
    createdAt         varchar,
    updatedAt         varchar,
    memberId          int not null
        constraint FK_MemberAddress_Member
            references Member,
    countryId         int not null
        constraint FK_MemberAddress_Country
            references Country,
    locationId        int not null
        constraint FK_MemberAddress_Location
            references Location,

)
go

create table [User]
(
    id             int          not null
        primary key,
    firstname      varchar(255),
    surname        varchar(255),
    email          varchar(255) not null,
    username       varchar(255) not null,
    phonenumber    varchar(255),
    status         int          not null,
    isOwner        bit          not null,
    membergroupsId int          not null
        constraint FK_User_MemberGroup
            references MemberGroup,
    smsApproved    bit          not null,
    userlevelId    int          not null
        constraint FK_User_ShopUserlevels
            references ShopUserlevels
)
go

create table sysdiagrams
(
    name         sysname not null,
    principal_id int     not null,
    diagram_id   int identity
        primary key,
    version      int,
    definition   varbinary(max),
    constraint UK_principal_name
        unique (principal_id, name)
)
go

exec sp_addextendedproperty 'microsoft_database_tools_support', 1, 'SCHEMA', 'dbo', 'TABLE', 'sysdiagrams'
go

