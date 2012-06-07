namespace DemoAgenda.Models
{
    public class Agenda
    {
        public string MensagemInicial()
        {
            return "Bom dia!";
        }

        public string MensagemInicial(string texto)
        {
            return "Bom dia " + texto + "!";
        }

    }
}