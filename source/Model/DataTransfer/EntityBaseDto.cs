using System;
namespace Model.DataTransfer
{
    public abstract class EntityBaseDto
    {
        public DateTime CreatedUtc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedUtc { get; set; }
        public string ModifiedBy { get; set; }
    }
}
