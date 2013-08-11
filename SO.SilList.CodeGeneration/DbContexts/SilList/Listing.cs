//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SO.SilList.CodeGeneration.DbContexts.SilList
{
    using System;
    using System.Collections.Generic;
    
    public partial class Listing
    {
        public Listing()
        {
            this.ListingCategories = new HashSet<ListingCategory>();
            this.ListingImages = new HashSet<ListingImage>();
        }
    
        public System.Guid listingId { get; set; }
        public Nullable<System.Guid> listingDetailId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Nullable<int> siteId { get; set; }
        public Nullable<int> memberId { get; set; }
        public Nullable<int> listingTypeId { get; set; }
        public Nullable<int> createdBy_ { get; set; }
        public Nullable<int> modifiedBy { get; set; }
        public System.DateTime created { get; set; }
        public System.DateTime modified { get; set; }
        public bool isActive { get; set; }
    
        public virtual ListingType ListingType { get; set; }
        public virtual ICollection<ListingCategory> ListingCategories { get; set; }
        public virtual ICollection<ListingImage> ListingImages { get; set; }
    }
}