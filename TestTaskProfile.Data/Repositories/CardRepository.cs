using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.Data.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly DatabaseContext _databaseContext;
        public CardRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await _databaseContext.Cards.ToListAsync();
        }

        public async Task<Card> GetCardById(Guid Id)
        {
            return await _databaseContext.Cards.FirstOrDefaultAsync(card => card.Id == Id);
        }

        public async Task<Card> AddCard(Card card)
        {
            await _databaseContext.Cards.AddAsync(card);
            await _databaseContext.SaveChangesAsync();
            return card;
        }

        public async Task<Card> UpdateCard(Card card)
        {
            var dbCard = await _databaseContext.Cards.FirstOrDefaultAsync(c => c.Id == card.Id);

            if (dbCard == null)
            {
                return null;
            }

            _databaseContext.Cards.Update(card);
            await _databaseContext.SaveChangesAsync();

            return card;
        }

        public async Task DeleteCard(Guid Id)
        {
            var dbCard = await _databaseContext.Cards.FirstOrDefaultAsync(c => c.Id == Id);

            if (dbCard == null)
            {
                return;
            }

            _databaseContext.Cards.Remove(dbCard);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
