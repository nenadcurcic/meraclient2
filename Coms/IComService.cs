using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeraClient2.Coms
{
    public interface IComService
    {
        Task<int> GetWordsCount(string text);
        Task<TextContainer> GetArticleBySubject(string subject);
        Task<Catalog> GetArticlesList();
    }
}
