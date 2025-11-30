using Project_Tanamin.app.model;
using System;
using System.Collections.Generic;

namespace Project_Tanamin.app.controller
{
    public class c_PembayaranSupplier
    {
        private readonly c_supplier csupp;

        public c_PembayaranSupplier()
        {
            csupp = new c_supplier();
        }

        public int ProsesPembayaranSupplier(
            string supplierName,
            decimal nominal,
            List<(m_produk produk, int jumlah)> keranjang)
        {
            DateTime now = DateTime.Now;

            return csupp.InsertPembelian(now, supplierName, nominal, keranjang);
        }
    }
}
