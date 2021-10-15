using BitirmeProjesi.Common.DTOs.Member;

namespace BitirmeProjesi.Common.Service.WorkContext
{
    public interface IWorkContext
    {
        MemberResponse CurrentUser { get; set; }
    }
}
