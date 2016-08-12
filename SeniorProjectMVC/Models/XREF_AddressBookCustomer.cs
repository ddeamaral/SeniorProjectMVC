namespace SeniorProjectMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XREF_AddressBookCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int XREF_AddressBookCustomer_ID { get; set; }

        public int Customer_ID { get; set; }

        public int AddresBook_ID { get; set; }

        public virtual AddressBook AddressBook { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
