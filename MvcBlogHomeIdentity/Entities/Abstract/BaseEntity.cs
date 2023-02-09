﻿namespace MVCBlogSitesi.Entities.Abstract
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
