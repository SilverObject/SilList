
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SO.SilList.CodeGeneration.DbContexts.SilList
{
     
    [Table("JobCategories", Schema = "dbo" )]
    [Serializable]
    public partial class JobCategoriesVo
    {
    		
    	[DisplayName("job Category Type Id")]
    	[Required]
        public int jobCategoryTypeId { get; set; }
    		
    	[DisplayName("job Id")]
        public Nullable<System.Guid> jobId { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public Nullable<bool> isActive { get; set; }
      
    	public JobCategoriesVo(){
    			
    	
    	 //this.isActive = true;
    	}
    }
}
