namespace PortalCliente.DTO
{
    public class OpcaoLinhaDigitavel : Base
    {
        [AtributoBind(ChavePrimaria = true
            , ProcedureInserir = "SPIOpcaoLinhaDigitavelByOpcaoId")]
        public int OpcaoId { get; set; }
        public string LinhaDigitavel { get; set; }
        public string CodigoBarras { get; set; }
    }
}
