﻿namespace RdvMS.Models.Rdv
{
    public class Rdv
    {
        public int Id { get; set; }
        public string NomPraticien   { get; set; }
        public string NomPatient { get; set;}
        public DateTime Date {  get; set; }
    }
}
