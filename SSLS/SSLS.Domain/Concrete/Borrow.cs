//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSLS.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    
    public partial class Borrow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Borrow()
        {
            this.Fine = new HashSet<Fine>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> BorrowDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<System.DateTime> ShouldReturnDate { get; set; }
        public Nullable<bool> IsRenew { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fine> Fine { get; set; }
    }
}
