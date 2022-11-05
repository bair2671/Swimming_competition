using System.Linq;

namespace Model.Validator
{
    public class ProbaValidator : IValidator<Proba>
    {
        public void Validate(Proba entity)
        {
            string[] stiluri = { "fluture", "liber", "spate", "mixt" };
            if (entity.GetStil() == null)
                throw new ValidationException("Stilul nu poate fi vid!");
            if (!stiluri.Contains(entity.GetStil()))
                throw new ValidationException("Stil invalid!");
            int[] distante = { 50, 200, 800, 1500 };
            if (!distante.Contains(entity.GetDistanta()))
                throw new ValidationException("Distanta invalida!");
        }
    }
}
