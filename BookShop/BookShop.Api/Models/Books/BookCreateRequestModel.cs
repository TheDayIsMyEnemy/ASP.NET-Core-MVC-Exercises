using System.Collections.Generic;

namespace BookShop.Api.Models.Books
{
    public class BookCreateRequestModel : BookEditRequestModel
    {
        public List<string> Categories { get; set; } = new List<string>();
    }
}
