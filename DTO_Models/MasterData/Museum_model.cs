namespace DTO_Models.MasterData
{
    public class Museum_model : Datatable_model
    {
        public string? MUSEUM_ID { get; set; }

        public string? MUSEUM_NAME { get; set; }
        public string? ADDRESS { get; set; }
        public string? CITY { get; set; }
        public string? STATE { get; set; }
        public string? POSTAL { get; set; }
        public string? COUNTRY { get; set; }
        public string? PHONE { get; set; }
        public string? URL { get; set; }

        public string? STATUS { get; set; }

        public DateTime? CREATE_DT { get; set; }
            
        public DateTime? CREATE_DT_FROMDATE { get; set; }

        public DateTime? CREATE_DT_TODATE { get; set; }
    }
}
