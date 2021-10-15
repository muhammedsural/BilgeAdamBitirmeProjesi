namespace BitirmeProjesi.Common.Models
{
    public class WebApiResponse<T>
    {
        public WebApiResponse()
        {

        }
        public WebApiResponse(bool isSuccess,string resultMessage)
        {
            this.IsSuccess = isSuccess;
            this.ResultMessage = resultMessage;
        }

        public WebApiResponse(bool isSuccess, string resultMessage, T resultData)
        {
            this.IsSuccess = isSuccess;
            this.ResultMessage = resultMessage;
            this.ResultData = resultData;
        }

        public string ResultMessage { get; set; }
        public bool IsSuccess { get; set; }
        public T ResultData { get; set; }
    }
}
