using System.Runtime.Serialization;

namespace DashboardApp.Models.Responces
{
    [DataContract]
    public class BaseResponce
    {
        [DataMember]
        public string Status { get; set; }
    }


    [DataContract]
    public class BaseResponse<TData> : BaseResponce
    {
        [DataMember]
        public TData Data { get; set; }
    }
}
