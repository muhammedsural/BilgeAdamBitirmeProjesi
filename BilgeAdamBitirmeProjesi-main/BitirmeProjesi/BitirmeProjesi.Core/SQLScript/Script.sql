CREATE TABLE Region
(
    id   INTEGER      NOT NULL PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);
CREATE TABLE CurrentAccount
(
    id        INTEGER      NOT NULL PRIMARY KEY,
    code      VARCHAR(255),
    title     VARCHAR(255) NOT NULL,
    balance   NUMERIC,
    riskLimit NUMERIC,
    createdAt DATETIME,
    updatedAt DATETIME,
    memberId  INTEGER      NOT NULL
);
CREATE TABLE Distributor
(
    id            INTEGER      NOT NULL PRIMARY KEY,
    name          VARCHAR(255) NOT NULL,
    email         VARCHAR(255),
    phone         VARCHAR(255),
    contactPerson VARCHAR(255)
);
CREATE TABLE DistributorToProduct
(
    id            INTEGER NOT NULL PRIMARY KEY,
    distributorID INTEGER NOT NULL,
    productID     INTEGER NOT NULL
);
CREATE TABLE ExtraInfo
(
    id        INTEGER      NOT NULL PRIMARY KEY,
    name      VARCHAR(255) NOT NULL,
    sortOrder INTEGER
);
CREATE TABLE ExtraInfoToProduct
(
    id          INTEGER NOT NULL PRIMARY KEY,
    value       VARCHAR NOT NULL,
    extraInfoId INTEGER NOT NULL,
    productId   INTEGER NOT NULL
);
CREATE TABLE Selection
(
    id               INTEGER NOT NULL PRIMARY KEY,
    title            VARCHAR(255),
    sortOrder        INTEGER NOT NULL,
    selectionGroupId INTEGER NOT NULL
);
CREATE TABLE SelectionGroup
(
    id        INTEGER      NOT NULL PRIMARY KEY,
    title     VARCHAR(255) NOT NULL,
    sortOrder INTEGER      NOT NULL
);
CREATE TABLE SelectionToProduct
(
    id          INTEGER NOT NULL PRIMARY KEY,
    selectionId INTEGER NOT NULL,
    productId   INTEGER NOT NULL
);
CREATE TABLE ProductProtection
(
    id               INTEGER NOT NULL PRIMARY KEY,
    isPriceProtected BIT     NOT NULL,
    isStockProtected BIT     NOT NULL,
    productid        INTEGER NOT NULL
);
CREATE TABLE BillingAddress
(
    id                         INTEGER      NOT NULL PRIMARY KEY,
    firstname                  VARCHAR(255) NOT NULL,
    surname                    VARCHAR(255) NOT NULL,
    country                    VARCHAR(128) NOT NULL,
    location                   VARCHAR(128) NOT NULL,
    subLocation                VARCHAR(128),
    address                    VARCHAR      NOT NULL,
    phonenumber                VARCHAR(32),
    mobilePhonenumber          VARCHAR(32)  NOT NULL,
    orderId                    INTEGER      NOT NULL,
    invoiceType                VARCHAR(10)  NOT NULL,
    taxNo                      INTEGER      NOT NULL,
    taxOffice                  VARCHAR(255) NOT NULL,
    identityRegistrationnumber INTEGER      NOT NULL
);
CREATE TABLE FavouritedProduct
(
    id        INTEGER NOT NULL PRIMARY KEY,
    memberId  INTEGER NOT NULL,
    productId INTEGER NOT NULL
);
CREATE TABLE Error
(
    code         INTEGER NOT NULL PRIMARY KEY,
    errorMessage VARCHAR,
    errorCode    INTEGER
);
CREATE TABLE ShopTokens
(
    id   INTEGER NOT NULL PRIMARY KEY,
    code VARCHAR(255)
);
CREATE TABLE QuickCart
(
    id       INTEGER      NOT NULL PRIMARY KEY,
    name     VARCHAR(255) NOT NULL,
    url      VARCHAR(255) NOT NULL,
    shortUrl VARCHAR(255)
);
CREATE TABLE Town
(
    id          INTEGER      NOT NULL PRIMARY KEY,
    name        VARCHAR(255) NOT NULL,
    status      BIT          NOT NULL,
    locationId  INTEGER      NOT NULL,
    townGroupId INTEGER      NOT NULL
);
CREATE TABLE TownGroup
(
    id     INTEGER      NOT NULL PRIMARY KEY,
    name   VARCHAR(255) NOT NULL,
    status BIT
);
CREATE TABLE ShippingCompany
(
    id                                INTEGER      NOT NULL PRIMARY KEY,
    name                              VARCHAR(255) NOT NULL,
    status                            VARCHAR      NOT NULL,
    extraPrice                        INTEGER,
    extraVolumetricWeightPrice        INTEGER,
    freeShipmentOrderPrice            INTEGER,
    freeShipmentVolumetricWeightLimit BIT,
    sortOrder                         INTEGER,
    companyCode                       VARCHAR(255),
    paymentType                       VARCHAR,
    shippingProviderId                INTEGER      NOT NULL
);
CREATE TABLE ShippingRate
(
    id                    INTEGER NOT NULL PRIMARY KEY,
    volumetricWeightStart BIT     NOT NULL,
    volumetricWeightEnd   BIT     NOT NULL,
    rate                  BIT     NOT NULL,
    regionId              INTEGER NOT NULL,
    shippingCompanyId     INTEGER NOT NULL
);
CREATE TABLE Category
(
    id                         INTEGER      NOT NULL PRIMARY KEY,
    name                       VARCHAR(255) NOT NULL,
    slug                       VARCHAR(255),
    sortOrder                  INTEGER,
    status                     BIT          NOT NULL,
    distributorCode            VARCHAR(255),
    [percent]                  INTEGER,
    imageFile                  VARCHAR(255),
    distributor                VARCHAR(128),
    displayShowcaseContent     INTEGER,
    showcaseContent            VARCHAR,
    showcaseContentDisplayType INTEGER      NOT NULL,
    hasChildren                VARCHAR,
    metaKeywords               VARCHAR,
    metaDescription            VARCHAR,
    pageTitle                  VARCHAR,
    parentId                   INTEGER      NOT NULL,
    createdAt                  DATETIME,
    updatedAt                  DATETIME
);
CREATE TABLE [Label]
(
    id              INTEGER      NOT NULL PRIMARY KEY,
    name            VARCHAR(255) NOT NULL,
    sortOrder       INTEGER,
    hasChildren     BIT,
    slug            VARCHAR(255),
    metaTitle       VARCHAR(255),
    metaKeywords    VARCHAR(255),
    metaDescription VARCHAR(255),
    status          BIT          NOT NULL,
    createdAt       DATETIME,
    updatedAt       DATETIME,
    parentId        INTEGER      NOT NULL
);
CREATE TABLE LabelToProduct
(
    id        INTEGER NOT NULL PRIMARY KEY,
    labelId   INTEGER NOT NULL,
    productId INTEGER NOT NULL
);
CREATE TABLE Currency
(
    id           INTEGER     NOT NULL PRIMARY KEY,
    label        VARCHAR(50) NOT NULL,
    buyingPrice  numeric,
    sellingPrice numeric,
    abbr         VARCHAR(5),
    updatedAt    DATETIME,
    status       BIT,
    isPrimary    BIT
);
CREATE TABLE Maillist
(
    id               INTEGER      NOT NULL PRIMARY KEY,
    name             VARCHAR(255) NOT NULL,
    email            VARCHAR(255) NOT NULL,
    lastMailSentDate DATETIME,
    creatorIpAddress VARCHAR(64),
    createdAt        DATETIME,
    updatedAt        DATETIME,
    maillistGroupId        INTEGER      NOT NULL
);
CREATE TABLE MaillistGroup
(
    id   INTEGER      NOT NULL PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);
CREATE TABLE Brand
(
    id                     INTEGER      NOT NULL PRIMARY KEY,
    name                   VARCHAR(255) NOT NULL,
    slug                   VARCHAR(255),
    sortOrder              INTEGER,
    status                 BIT          NOT NULL,
    distributorCode        VARCHAR(255),
    distributor            VARCHAR(255),
    imageFile              VARCHAR(255),
    showcaseContent        VARCHAR,
    displayShowcaseContent BIT,
    metaKeywords           VARCHAR,
    metaDescription        VARCHAR,
    pageTitle              VARCHAR(255),
    createdAt              DATETIME,
    updatedAt              DATETIME
);
CREATE TABLE Payment
(
    id                  INTEGER      NOT NULL PRIMARY KEY,
    memberFirstname     VARCHAR(255) NOT NULL,
    memberSurname       VARCHAR(255) NOT NULL,
    memberEmail         VARCHAR(255) NOT NULL,
    memberPhone         VARCHAR(255),
    paymentTypeName     VARCHAR(128) NOT NULL,
    paymentProviderCode VARCHAR(64)  NOT NULL,
    paymentProviderName VARCHAR(128) NOT NULL,
    paymentGatewayName  VARCHAR(128) NOT NULL,
    paymentGatewayCode  VARCHAR(128) NOT NULL,
    bankName            VARCHAR(64),
    deviceType          VARCHAR      NOT NULL,
    clientIp            VARCHAR(32)  NOT NULL,
    currencyRates       VARCHAR(255) NOT NULL,
    amount              numeric NOT NULL,
    finalAmount         numeric NOT NULL,
    sumOfGainedPoints   numeric,
    installment         numeric NOT NULL,
    installmentRate     numeric NOT NULL,
    extraInstallment    INTEGER,
    currency            VARCHAR(12)  NOT NULL,
    transactionId       INTEGER,
    memberNote          VARCHAR,
    userNote            VARCHAR,
    status              VARCHAR      NOT NULL,
    errorMessage        VARCHAR,
    cardSavingSystem    VARCHAR(255),
    createdAt           DATETIME,
    memberid            INTEGER      NOT NULL
);
CREATE TABLE PaymentProvider
(
    id            INTEGER      NOT NULL PRIMARY KEY,
    code          VARCHAR(255) NOT NULL,
    name          VARCHAR(255) NOT NULL,
    status        BIT          NOT NULL,
    paymentTypeId INTEGER      NOT NULL,
    settingsId      INTEGER      NOT NULL
);
CREATE TABLE PaymentProviderSetting
(
    id       INTEGER      NOT NULL PRIMARY KEY,
    varKey   VARCHAR(255) NOT NULL,
    varValue VARCHAR      NOT NULL
);
CREATE TABLE PaymentGateway
(
    id                INTEGER      NOT NULL PRIMARY KEY,
    code              VARCHAR(255) NOT NULL,
    name              VARCHAR(255) NOT NULL,
    status            VARCHAR      NOT NULL,
    sortOrder         INTEGER      NOT NULL,
    paymentProviderId INTEGER      NOT NULL,
    settingsId          INTEGER      NOT NULL
);
CREATE TABLE PaymentGatewaySetting
(
    id               INTEGER      NOT NULL PRIMARY KEY,
    varKey           VARCHAR(255) NOT NULL,
    varValue         VARCHAR(255) NOT NULL,
    paymentGatewayId INTEGER      NOT NULL
);
CREATE TABLE PaymentType
(
    id   INTEGER      NOT NULL PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);
CREATE TABLE ProductSpecialInfo
(
    id        INTEGER      NOT NULL PRIMARY KEY,
    title     VARCHAR(255) NOT NULL,
    content   VARCHAR      NOT NULL,
    status    BIT          NOT NULL,
    productid INTEGER      NOT NULL
);
CREATE TABLE ShopCampaigns
(
    id    INTEGER NOT NULL PRIMARY KEY,
    label VARCHAR(255)
);
CREATE TABLE PurchaseLimitation
(
    id           INTEGER      NOT NULL PRIMARY KEY,
    name         VARCHAR(255) NOT NULL,
    minimumLimit numeric,
    maximumLimit numeric,
    type         VARCHAR      NOT NULL,
    status       BIT
);
CREATE TABLE PurchaseLimitationItem
(
    id            INTEGER NOT NULL PRIMARY KEY,
    brandId       INTEGER NOT NULL,
    categoryId    INTEGER NOT NULL,
    limitationId  INTEGER NOT NULL,
    memberGroupId INTEGER NOT NULL,
    productId     INTEGER NOT NULL
);
CREATE TABLE [Location]
(
    id         INTEGER      NOT NULL PRIMARY KEY,
    name       VARCHAR(255) NOT NULL,
    status     BIT          NOT NULL,
    predefined BIT,
    countryid  INTEGER      NOT NULL,
    regionid   INTEGER      NOT NULL
);
CREATE TABLE Tag
(
    id              INTEGER      NOT NULL PRIMARY KEY,
    name            VARCHAR(255) NOT NULL,
    count           INTEGER,
    pageTitle       VARCHAR,
    metaDescription VARCHAR,
    metaKeywords    VARCHAR
);
CREATE TABLE Cart
(
    id                INTEGER      NOT NULL PRIMARY KEY,
    sessionId         VARCHAR(255) NOT NULL,
    locked            BIT,
    createdAt         DATETIME,
    updatedAt         DATETIME,
    chosenPromotionId INTEGER      NOT NULL,
    memberId          INTEGER      NOT NULL,
    chosenTokenId     INTEGER      NOT NULL,
    itemsId           INTEGER      NOT NULL
);
CREATE TABLE CartItem
(
    id              INTEGER  NOT NULL PRIMARY KEY,
    parentProductId INTEGER,
    quantity        numeric NOT NULL,
    categoryId      INTEGER,
    createdAt       DATETIME,
    updatedAt       DATETIME NOT NULL,
    cartId          INTEGER  NOT NULL,
    productId       INTEGER  NOT NULL,
    attributesId       INTEGER  NOT NULL
);
CREATE TABLE CartItemAttribute
(
    id         INTEGER NOT NULL PRIMARY KEY,
    name       VARCHAR(255),
    value      VARCHAR,
    createdAt  DATETIME,
    cartItemId INTEGER NOT NULL
);
CREATE TABLE [Order]
(
    id                      INTEGER       NOT NULL PRIMARY KEY,
    customerFirstname       VARCHAR(255)  NOT NULL,
    customerSurname         VARCHAR(255)  NOT NULL,
    customerEmail           VARCHAR(255)  NOT NULL,
    customerPhone           VARCHAR(32),
    paymentTypeName         VARCHAR(128)  NOT NULL,
    paymentProviderCode     VARCHAR(128)  NOT NULL,
    paymentProviderName     VARCHAR(128)  NOT NULL,
    paymentGatewayCode      VARCHAR(128)  NOT NULL,
    paymentGatewayName      VARCHAR(128)  NOT NULL,
    bankName                VARCHAR(128),
    clientIp                VARCHAR(32)   NOT NULL,
    userAgent               VARCHAR(1024),
    currency                VARCHAR(32)   NOT NULL,
    currencyRates           VARCHAR(255)  NOT NULL,
    amount                  NUMERIC NOT NULL,
    couponDiscount          numeric NOT NULL,
    taxAmount               NUMERIC NOT NULL,
    promotionDiscount       NUMERIC NOT NULL,
    generalAmount           numeric NOT NULL,
    shippingAmount          numeric NOT NULL,
    additionalServiceAmount numeric NOT NULL,
    finalAmount             numeric NOT NULL,
    sumOfGainedPoints       numeric,
    installment             INTEGER,
    installmentRate         numeric,
    extraInstallment        INTEGER,
    transactionId           VARCHAR(255),
    hasUserNote             BIT,
    status                  VARCHAR       NOT NULL,
    paymentStatus           VARCHAR       NOT NULL,
    errorMessage            VARCHAR,
    deviceType              VARCHAR       NOT NULL,
    referrer                VARCHAR,
    invoicePrintCount       INTEGER,
    useGiftPackage          BIT,
    giftNote                VARCHAR,
    memberGroupName         VARCHAR(255),
    usePromotion            BIT,
    shippingProviderCode    VARCHAR(128),
    shippingProviderName    VARCHAR(128),
    shippingCompanyName     VARCHAR(128),
    shippingPaymentType     VARCHAR,
    shippingTrackingCode    VARCHAR(255),
    source                  VARCHAR(255)  NOT NULL,
    createdAt               DATETIME,
    updatedAt               DATETIME,
    maillistId              INTEGER       NOT NULL,
    memberId                INTEGER       NOT NULL,
    orderDetailsId          INTEGER       NOT NULL,
    orderItemsId            INTEGER       NOT NULL,
    shippingAddressId       INTEGER       NOT NULL,
    billingAddressId        INTEGER       NOT NULL
);
CREATE TABLE OrderAddress
(
    id                INTEGER      NOT NULL PRIMARY KEY,
    firstname         VARCHAR(255) NOT NULL,
    surname           VARCHAR(255) NOT NULL,
    country           VARCHAR(128) NOT NULL,
    location          VARCHAR(128) NOT NULL,
    subLocation       VARCHAR(128),
    address           VARCHAR      NOT NULL,
    phonenumber       VARCHAR(32),
    mobilePhonenumber VARCHAR(32)  NOT NULL,
    orderId           INTEGER      NOT NULL
);
CREATE TABLE OrderDetail
(
    id       INTEGER      NOT NULL PRIMARY KEY,
    varKey   VARCHAR(255) NOT NULL,
    varValue VARCHAR      NOT NULL,
    orderId  INTEGER      NOT NULL
);
CREATE TABLE OrderRefundRequest
(
    id                 INTEGER      NOT NULL PRIMARY KEY,
    code               VARCHAR(255) NOT NULL,
    status             VARCHAR      NOT NULL,
    fee                numeric NOT NULL,
    cancellationReason VARCHAR(512),
    createdAt          DATETIME,
    updatedAt          DATETIME,
    memberId           INTEGER      NOT NULL,
    orderId            INTEGER      NOT NULL
);
CREATE TABLE OrderRefundRequestItem
(
    id                   INTEGER       NOT NULL PRIMARY KEY,
    amount               numeric NOT NULL,
    reason               VARCHAR(1024) NOT NULL,
    details              VARCHAR       NOT NULL,
    createdAt            DATETIME,
    updatedAt            DATETIME,
    orderItemId          INTEGER       NOT NULL,
    orderRefundRequestId INTEGER       NOT NULL
);
CREATE TABLE OrderItem
(
    id                        INTEGER       NOT NULL PRIMARY KEY,
    productName               VARCHAR(255)  NOT NULL,
    productSku                VARCHAR(255)  NOT NULL,
    productBarcode            INTEGER,
    productPrice              numeric NOT NULL,
    productCurrency           VARCHAR(32)   NOT NULL,
    productQuantity           numeric NOT NULL,
    productTax                INTEGER       NOT NULL,
    productDiscount           numeric NOT NULL,
    productMoneyOrderDiscount numeric NOT NULL,
    productWeight             NUMERIC NOT NULL,
    productStockTypeLabel     VARCHAR(255)  NOT NULL,
    isProductPromotioned      BIT,
    discount                  numeric NOT NULL,
    orderId                   INTEGER       NOT NULL,
    productId                 INTEGER       NOT NULL,
    orderItemCustomizationsId INTEGER       NOT NULL,
    orderItemSubscriptionId   INTEGER       NOT NULL
);
CREATE TABLE OrderItemSubscription
(
    id INTEGER NOT NULL PRIMARY KEY
);
CREATE TABLE OrderItemCustomization
(
    id                                 INTEGER NOT NULL PRIMARY KEY,
    productCustomizationGroupId        INTEGER,
    productCustomizationGroupName      VARCHAR(255),
    productCustomizationGroupSortOrder INTEGER,
    productCustomizationFieldId        INTEGER,
    productCustomizationFieldType      VARCHAR(64),
    productCustomizationFieldName      VARCHAR(255),
    productCustomizationFieldValue     VARCHAR,
    cartItemAttributeId                INTEGER
);
CREATE TABLE PreOrderInfo
(
    id                                INTEGER      NOT NULL PRIMARY KEY,
    sessionId                         VARCHAR(255) NOT NULL,
    customerFirstname                 VARCHAR(255),
    customerSurname                   VARCHAR(255),
    customerEmail                     VARCHAR(255),
    shippingFirstname                 VARCHAR(255) NOT NULL,
    shippingSurname                   VARCHAR(255) NOT NULL,
    shippingAddress                   VARCHAR      NOT NULL,
    shippingPhonenumber               VARCHAR(32)  NOT NULL,
    shippingMobilePhonenumber         VARCHAR(32)  NOT NULL,
    shippingLocationName              VARCHAR(128) NOT NULL,
    shippingTown                      VARCHAR(128) NOT NULL,
    billingFirstname                  VARCHAR(255) NOT NULL,
    billingSurname                    VARCHAR(255) NOT NULL,
    billingAddress                    VARCHAR      NOT NULL,
    billingPhonenumber                VARCHAR(32)  NOT NULL,
    billingMobilePhonenumber          VARCHAR(32)  NOT NULL,
    billingLocationName               VARCHAR(128) NOT NULL,
    billingTown                       VARCHAR(128) NOT NULL,
    billingInvoiceType                VARCHAR      NOT NULL,
    billingIdentityRegistrationnumber INTEGER,
    billingTaxOffice                  VARCHAR(255),
    billingTaxNo                      INTEGER,
    isEinvoiceUser                    BIT,
    useGiftPackage                    BIT,
    giftNote                          VARCHAR,
    imageFile                         VARCHAR(128),
    deliveryDate                      DATETIME,
    deliveryTime                      VARCHAR(128),
    createdAt                         DATETIME,
    updatedAt                         DATETIME,
    billingCountryId                  INTEGER      NOT NULL,
    billingLocationId                 INTEGER      NOT NULL,
    shippingCompanyId                 INTEGER      NOT NULL,
    shippingCountryId                 INTEGER      NOT NULL,
    shippingLocationId                INTEGER      NOT NULL,
    memberShippingAddressId           INTEGER      NOT NULL,
    memberBillingAddressId            INTEGER      NOT NULL
);
CREATE TABLE OrderUserNote
(
    id            INTEGER      NOT NULL PRIMARY KEY,
    userEmail     VARCHAR(255) NOT NULL,
    userFirstname VARCHAR(255),
    userSurname   VARCHAR(255),
    note          VARCHAR,
    createdAt     DATETIME,
    updatedAt     DATETIME,
    orderId       INTEGER      NOT NULL
);
CREATE TABLE InstallmentRate
(
    id               INTEGER       NOT NULL PRIMARY KEY,
    installment      INTEGER       NOT NULL,
    rate             NUMERIC NOT NULL,
    paymentGatewayId INTEGER       NOT NULL
);
CREATE TABLE Preference
(
    id       INTEGER NOT NULL PRIMARY KEY,
    varKey   VARCHAR(255),
    varValue VARCHAR
);
CREATE TABLE Theme
(
    id            INTEGER      NOT NULL PRIMARY KEY,
    platform      VARCHAR      NOT NULL,
    type          VARCHAR      NOT NULL,
    name          VARCHAR(255) NOT NULL,
    preset        VARCHAR(255),
    directoryName VARCHAR(255),
    status        BIT          NOT NULL,
    revision      INTEGER      NOT NULL,
    createdAt     DATETIME,
    updatedAt     DATETIME
);
CREATE TABLE Asset
(
    [key]         VARCHAR(255) PRIMARY KEY,
    contentType VARCHAR(255),
    attachment  VARCHAR,
    createdAt   DATETIME,
    updatedAt   DATETIME
);
CREATE TABLE Shipment
(
    id              INTEGER NOT NULL PRIMARY KEY,
    barcode         VARCHAR(255),
    waybillNo       VARCHAR(255),
    invoiceKey      VARCHAR(255),
    cargoOffice     VARCHAR(255),
    code            VARCHAR(255),
    deliveryType    VARCHAR(255),
    invoiceIncluded BIT,
    payAtDoorAmount numeric,
    createdAt       DATETIME,
    status          BIT     NOT NULL,
    orderId         INTEGER,
    barcodeImage    VARCHAR,
    trackingUrl     VARCHAR(255)
);
CREATE TABLE ShippingAddress
(
    id                INTEGER      NOT NULL PRIMARY KEY,
    firstname         VARCHAR(255) NOT NULL,
    surname           VARCHAR(255) NOT NULL,
    country           VARCHAR(128) NOT NULL,
    location          VARCHAR(128) NOT NULL,
    subLocation       VARCHAR(128) NOT NULL,
    address           VARCHAR      NOT NULL,
    phonenumber       VARCHAR(32),
    mobilePhonenumber VARCHAR(32),
    orderId           INTEGER      NOT NULL
);
CREATE TABLE ShippingProvider
(
    id                 INTEGER       NOT NULL PRIMARY KEY,
    code               VARCHAR(64)   NOT NULL,
    name               VARCHAR(255)  NOT NULL,
    trackingUrl        VARCHAR(1024) NOT NULL,
    trackingFormMethod VARCHAR,
    payload            DATE,
    settingsId         INTEGER       NOT NULL
);
CREATE TABLE ShippingProviderSetting
(
    id                 INTEGER      NOT NULL PRIMARY KEY,
    varKey             VARCHAR(255) NOT NULL,
    varValue           VARCHAR      NOT NULL,
    shippingProviderId INTEGER      NOT NULL
);
CREATE TABLE ShipmentItem
(
    id            INTEGER  NOT NULL PRIMARY KEY,
    rootProductId INTEGER,
    amount        INTEGER  NOT NULL,
    price         numeric NOT NULL,
    productLabel  VARCHAR(255),
    currency      VARCHAR  NOT NULL,
    tax           INTEGER,
    dm3           numeric NOT NULL,
    createdAt     DATETIME,
    status        BIT      NOT NULL,
    updatedAt     DATETIME NOT NULL,
    orderItemId   INTEGER  NOT NULL,
    productId     INTEGER  NOT NULL,
    shipmentId    INTEGER  NOT NULL
);
CREATE TABLE Country
(
    id     INTEGER      NOT NULL PRIMARY KEY,
    name   VARCHAR(255) NOT NULL,
    status BIT          NOT NULL
);
CREATE TABLE Product
(
    id                     INTEGER      NOT NULL PRIMARY KEY,
    name                   VARCHAR(255) NOT NULL,
    slug                   VARCHAR,
    fullName               VARCHAR(255) NOT NULL,
    sku                    VARCHAR(255) NOT NULL,
    barcode                INTEGER,
    price1                 numeric NOT NULL,
    warranty               INTEGER,
    tax                    INTEGER,
    stockAmount            numeric,
    volumetricWeight       numeric,
    buyingPrice            numeric,
    stockTypeLabel         VARCHAR,
    discount               numeric,
    discountType           INTEGER,
    moneyOrderDiscount     numeric,
    status                 BIT          NOT NULL,
    taxIncluded            BIT,
    distributor            VARCHAR(255),
    isGifted               BIT,
    gift                   VARCHAR(255),
    customShippingDisabled BIT          NOT NULL,
    customShippingCost     numeric,
    marketPriceDetail      VARCHAR(255) NOT NULL,
    createdAt              DATETIME,
    updatedAt              DATETIME,
    metaKeywords           VARCHAR      NOT NULL,
    metaDescription        VARCHAR      NOT NULL,
    pageTitle              VARCHAR(255) NOT NULL,
    hasOption              BIT          NOT NULL,
    shortDetails           VARCHAR(512) NOT NULL,
    searchKeywords         VARCHAR(255) NOT NULL,
    installmentThreshold   VARCHAR(10)  NOT NULL,
    homeSortOrder          INTEGER,
    popularSortOrder       INTEGER,
    brandSortOrder         INTEGER,
    featuredSortOrder      INTEGER,
    campaignedSortOrder    INTEGER,
    newSortOrder           INTEGER,
    discountedSortOrder    INTEGER,
    brandId                INTEGER      NOT NULL,
    currencyId             INTEGER      NOT NULL,
    parentId               INTEGER      NOT NULL,
    countdownId            INTEGER      NOT NULL,
    pricesId               INTEGER      NOT NULL,
    imagesId               INTEGER      NOT NULL,
    productToCategoriesId  INTEGER      NOT NULL
);
CREATE TABLE ProductDetail
(
    id           INTEGER      NOT NULL PRIMARY KEY,
    sku          VARCHAR(255) NOT NULL,
    details      VARCHAR      NOT NULL,
    extraDetails VARCHAR      NOT NULL,
    productId    INTEGER      NOT NULL
);
CREATE TABLE ProductPrice
(
    id        INTEGER NOT NULL PRIMARY KEY,
    value     numeric NOT NULL,
    type      INTEGER NOT NULL,
    productId INTEGER NOT NULL
);
CREATE TABLE ProductToCountDown
(
    id           INTEGER NOT NULL PRIMARY KEY,
    startDate    DATETIME,
    endDate      DATETIME,
    expireDate   DATETIME,
    useCountDown BIT     NOT NULL,
    productId    INTEGER NOT NULL
);
CREATE TABLE ProductToCategory
(
    id         INTEGER NOT NULL PRIMARY KEY,
    sortOrder  INTEGER,
    productId  INTEGER NOT NULL,
    categoryId INTEGER NOT NULL
);
CREATE TABLE SpecName
(
    id          INTEGER      NOT NULL PRIMARY KEY,
    name        VARCHAR(255) NOT NULL,
    slug        VARCHAR(255),
    choiceType  VARCHAR      NOT NULL,
    sortOrder   INTEGER,
    status      BIT          NOT NULL,
    specGroupId INTEGER      NOT NULL
);
CREATE TABLE SpecGroup
(
    id        INTEGER      NOT NULL PRIMARY KEY,
    name      VARCHAR(255) NOT NULL,
    sortOrder INTEGER,
    status    BIT          NOT NULL
);
CREATE TABLE SpecValue
(
    id          INTEGER      NOT NULL PRIMARY KEY,
    name        VARCHAR(255) NOT NULL,
    slug        VARCHAR(255),
    sortOrder   INTEGER,
    logo        VARCHAR,
    status      BIT          NOT NULL,
    specGroupId INTEGER      NOT NULL,
    specNameId  INTEGER      NOT NULL
);
CREATE TABLE SpecToProduct
(
    id          INTEGER NOT NULL PRIMARY KEY,
    productId   INTEGER NOT NULL,
    specGroupId INTEGER NOT NULL,
    specNameId  INTEGER NOT NULL,
    specValueId INTEGER NOT NULL
);
CREATE TABLE ProductImage
(
    id            INTEGER      NOT NULL PRIMARY KEY,
    filename      VARCHAR(255) NOT NULL,
    extension     VARCHAR      NOT NULL,
    directoryName INTEGER,
    revision      INTEGER,
    sortOrder     INTEGER      NOT NULL,
    productId     INTEGER      NOT NULL,
    attachment    VARCHAR      NOT NULL
);
CREATE TABLE ProductToTag
(
    id        INTEGER NOT NULL PRIMARY KEY,
    productId INTEGER NOT NULL,
    tagId     INTEGER NOT NULL
);
CREATE TABLE ProductButton
(
    id                INTEGER NOT NULL PRIMARY KEY,
    fastShipping      BIT,
    sameDayShipping   BIT,
    threeDaysDelivery BIT,
    fiveDaysDelivery  BIT,
    sevenDaysDelivery BIT,
    freeShipping      BIT,
    deliveryFromStock BIT,
    preOrderedProduct BIT,
    limitedStock      BIT,
    askStock          BIT,
    campaignedProduct BIT,
    productId         INTEGER NOT NULL
);
CREATE TABLE ProductComment
(
    id          INTEGER      NOT NULL PRIMARY KEY,
    title       VARCHAR(255) NOT NULL,
    content     VARCHAR      NOT NULL,
    status      BIT          NOT NULL,
    rank        INTEGER      NOT NULL,
    isAnonymous BIT          NOT NULL,
    createdAt   DATETIME,
    updatedAt   DATETIME,
    memberId    INTEGER      NOT NULL,
    productId   INTEGER      NOT NULL
);
CREATE TABLE Member
(
    id                              INTEGER      NOT NULL PRIMARY KEY,
    firstname                       VARCHAR(255) NOT NULL,
    surname                         VARCHAR(255) NOT NULL,
    email                           VARCHAR(255) NOT NULL,
    gender                          VARCHAR,
    birthDate                       DATETIME,
    phonenumber                    VARCHAR(255),
    mobilePhonenumber               VARCHAR(255),
    otherLocation                   VARCHAR(255),
    address                         VARCHAR,
    taxnumeric                       INTEGER,
    tcId                            INTEGER,
    status                          VARCHAR,
    lastLoginDate                   DATETIME,
    createdAt                       DATETIME,
    updatedAt                       DATETIME,
    zipCode                         INTEGER,
    commercialName                  VARCHAR(255),
    taxOffice                       VARCHAR(255),
    lastMailSentDate                DATETIME,
    lastIp                          VARCHAR(255),
    gainedPointAmount               numeric,
    spentPointAmount                numeric,
    allowedToCampaigns              BIT,
    referredMemberGainedPointAmount numeric,
    district                        VARCHAR(255),
    deviceType                      VARCHAR(255) NOT NULL,
    deviceInfo                      VARCHAR,
    countryId                       INTEGER      NOT NULL,
    locationId                      INTEGER      NOT NULL,
    memberGroupId                   INTEGER      NOT NULL,
    referredMemberId                INTEGER      NOT NULL
);
CREATE TABLE MemberAddress
(
    id                INTEGER NOT NULL PRIMARY KEY,
    name              VARCHAR(255),
    type              VARCHAR(20),
    firstname         VARCHAR(255),
    surname           VARCHAR(255),
    address           VARCHAR,
    subLocationName   VARCHAR(255),
    phonenumber      VARCHAR(32),
    mobilePhonenumber VARCHAR(32),
    tcId              INTEGER,
    taxnumeric         INTEGER,
    taxOffice         VARCHAR(255),
    invoiceType       VARCHAR(255),
    isEinvoiceUser    BIT,
    createdAt         VARCHAR,
    updatedAt         VARCHAR,
    memberId          INTEGER NOT NULL,
    countryId         INTEGER NOT NULL,
    locationId        INTEGER NOT NULL,
    subLocationId     INTEGER NOT NULL
);
CREATE TABLE MemberGroup
(
    id                     INTEGER      NOT NULL PRIMARY KEY,
    name                   VARCHAR(255) NOT NULL,
    priceIndex             INTEGER      NOT NULL,
    allowedPaymentGateways VARCHAR(512) NOT NULL
);
CREATE TABLE Options
(
    id            INTEGER      NOT NULL PRIMARY KEY,
    title         VARCHAR(255) NOT NULL,
    slug          VARCHAR(255),
    sortOrder     INTEGER,
    logo          VARCHAR,
    optionGroupId INTEGER      NOT NULL
);
CREATE TABLE OptionGroup
(
    id           INTEGER      NOT NULL PRIMARY KEY,
    title        VARCHAR(255) NOT NULL,
    slug         VARCHAR      NOT NULL,
    sortOrder    INTEGER      NOT NULL,
    filterStatus BIT          NOT NULL
);
CREATE TABLE OptionToProduct
(
    id              INTEGER NOT NULL PRIMARY KEY,
    parentProductId INTEGER NOT NULL,
    optionGroupId   INTEGER NOT NULL,
    optionId        INTEGER NOT NULL,
    productId       INTEGER NOT NULL
);
CREATE TABLE [User]
(
    id             INTEGER      NOT NULL PRIMARY KEY,
    firstname      VARCHAR(255),
    surname        VARCHAR(255),
    email          VARCHAR(255) NOT NULL,
    username       VARCHAR(255) NOT NULL,
    phonenumber   VARCHAR(255),
    status         INTEGER      NOT NULL,
    isOwner        BIT          NOT NULL,
    membergroupsId INTEGER      NOT NULL,
    smsApproved    BIT          NOT NULL,
    userlevelId    INTEGER      NOT NULL
);
CREATE TABLE ShopUserlevels
(
    id    INTEGER NOT NULL PRIMARY KEY,
    label VARCHAR,
    roles VARCHAR
);