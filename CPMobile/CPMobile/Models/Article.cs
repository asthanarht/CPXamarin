using System.Collections.Generic;
using CPMobile.Helper;

namespace CPMobile.Models
{
    public enum AuthorDataType
    {
        Article,
        Message,
        Tips,
        TechBlog,
        Comments
    }
    public class CPFeed
    {
        public Pagination pagination { get; set; }
        public List<Item> items { get; set; }
    }

    public class Pagination
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalItems { get; set; }
    }

    public class Author
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class DocType
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Category
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Tag
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class License
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class ThreadEditor
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string title { get; set; }
        public List<Author> authors { get; set; }

        private string _summary = string.Empty;
        public string summary
        {
            get
            {
                return  _summary;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _summary = value.ToString().Truncate(150);
                else
                    _summary = value;
            }
        }
        public string contentType { get; set; }
        public DocType docType { get; set; }
        public List<Category> categories { get; set; }
        public List<Tag> tags { get; set; }
        public License license { get; set; }
        public string createdDate { get; set; }
        public string modifiedDate { get; set; }
        public ThreadEditor threadEditor { get; set; }
        public string threadModifiedDate { get; set; }


        public double rating { get; set; }
        public int votes { get; set; }
        public double popularity { get; set; }
        public string websiteLink { get; set; }
        public string apiLink { get; set; }
        public int parentId { get; set; }
        public int threadId { get; set; }
        public int indentLevel { get; set; }
    }
}
