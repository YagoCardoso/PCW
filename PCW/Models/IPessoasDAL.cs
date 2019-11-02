using System.Collections.Generic;

namespace PCW.Models
{
   public interface IPessoasDAL
    {
        IEnumerable<Pessoas> GetAllPessoas();
        void AddPessoas(Pessoas pessoas);
        void UpdatePessoas(Pessoas pessoas);
        Pessoas GetPessoas(int? id);
        void DeletePessoas(int? id);

        Pessoas GetUsu(long cpf);
    }
}
