using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.Model
{

    public class ReflectTestModel: BaseModel
    {
        public ReflectTestModel()
        {
        }
        public ReflectTestModel2 model2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid AppId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StoreImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LinkName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LinkTel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MealTel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProvinceCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DistrictCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OperateTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LocationId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CommunityId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CateringTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Qualificationstatus_Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FoodManagentImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LicenceCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LevelImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PersonnelHealthImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mainSupplierImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SUBTIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ModifiedOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ApplyStatus_Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CreateStatu_Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NoPassReason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DataSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AuditorUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AuditorTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CreateOrgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CreateAppId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LocationAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AppName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BusinessLicenseImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int LevelReplying { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BusinessLicenseReplying { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ApplyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SourceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LegalPerson { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LegalTel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int LicenseStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LicenseExpire { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RestaurSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BusNet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CollDistr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BusinessTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StoreLogo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SfStreet { get; set; }

    }
}
