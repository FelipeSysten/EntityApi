﻿namespace WebApplicationApi.Dto
{
    public class EditarStatusDto
    {
        public int IdStatus { get; set; }
        public string NomeStatus { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        // Lista de IDs de pedidos a serem associados ao status
        public List<int> PedidoIds { get; set; } = new List<int>();
    }
}
