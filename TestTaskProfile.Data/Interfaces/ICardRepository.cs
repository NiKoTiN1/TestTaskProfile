using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.Data.Interfaces
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetAllCards();
        Task<Card> GetCardById(Guid Id);
        Task<Card> AddCard(Card card);
        Task<Card> UpdateCard(Card card);
        Task DeleteCard(Guid Id);
    }
}
