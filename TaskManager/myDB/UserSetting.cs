//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskManager.myDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserSetting
    {
        public string theme { get; set; }
        public string avatar { get; set; }
        public string login { get; set; }
    
        public virtual User User { get; set; }
    }
}
