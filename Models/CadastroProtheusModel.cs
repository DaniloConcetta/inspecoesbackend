namespace Inspecoes.Models
{
    public class CadastroProtheusModel
    {

    }
    //-----------------------------------------------------------------GrupoProdutoSBM
    public class GrupoProdutoSBM
    {
        public ICollection<itemsSBM> items { get; set; }
        public int   pagesize { get; set; }
        public int   length { get; set; }
        public int   page { get; set; }
        public bool  hasnext { get; set; }
    }

    public class itemsSBM
    {
        public int? id { get; set; }
        public string? codigo { get; set; }
        public string? descricao { get; set; }
    }
    //-----------------------------------------------------------------GrupoProdutoSBM
    //--------------------------------------------------------------------------OpsSC2
    public class OpSC2
    {
        public ICollection<itemsSC2> items { get; set; }
        public int pagesize { get; set; }
        public int length { get; set; }
        public int page { get; set; }
        public bool hasnext { get; set; }
    }

    public class itemsSC2
    {
        public int? id { get; set; }
        public string? opnumero { get; set; }
        public string? produtocodigo { get; set; }
        public string? produtodescricao { get; set; }
        public string? produtogrupo { get; set; }
        public int? quantidade { get; set; }
    }
    //--------------------------------------------------------------------------OpsSC2
}
