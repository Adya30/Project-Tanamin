CREATE TABLE users (
    id_user SERIAL PRIMARY KEY,
    username VARCHAR(100) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    nama_lengkap VARCHAR(200) NOT NULL,
    no_telp VARCHAR(20) UNIQUE NOT NULL,
    is_admin BOOLEAN DEFAULT FALSE
);

CREATE TABLE kategori (
    id_kategoriproduk SERIAL PRIMARY KEY,
    nama_kategori VARCHAR(150) NOT NULL
);

CREATE TABLE produk (
    id_produk SERIAL PRIMARY KEY,
    foto_produk BYTEA,
    nama_produk VARCHAR(200) NOT NULL,
    stok_produk INT NOT NULL,
    deskripsi TEXT,
    harga_satuan INT NOT NULL DEFAULT 0,
    is_deleted BOOLEAN DEFAULT FALSE,
    id_kategoriproduk INT,
    CONSTRAINT fk_kategori FOREIGN KEY (id_kategoriproduk)
        REFERENCES kategori(id_kategoriproduk)
        ON DELETE SET NULL
);

CREATE TABLE pembelian (
    id_pembelian SERIAL PRIMARY KEY,
	tanggal_pembelian DATE NOT NULL,
    nama_supplier VARCHAR(200) NOT NULL,
	pembayaran_supplier INT NOT NULL
);

CREATE TABLE detail_pembelian (
    id_detailpembelian SERIAL PRIMARY KEY,
    jumlah_pembelian INT NOT NULL,
    id_produk INT,
    id_pembelian INT,
    CONSTRAINT fk_detail_pembelian_produk FOREIGN KEY (id_produk)
        REFERENCES produk(id_produk)
        ON DELETE SET NULL,
    CONSTRAINT fk_detail_pembelian_pemb FOREIGN KEY (id_pembelian)
        REFERENCES pembelian(id_pembelian)
        ON DELETE CASCADE
);

CREATE TABLE transaksi (
    id_transaksi SERIAL PRIMARY KEY,
    tanggal_transaksi DATE NOT NULL,
    status_transaksi VARCHAR(300) NOT NULL,
    pembayaran VARCHAR(50) NOT NULL,
    alamat TEXT NOT NULL,
	total_transaksi INT,
    id_user INT,
    CONSTRAINT fk_transaksi_user FOREIGN KEY (id_user)
        REFERENCES users(id_user)
        ON DELETE SET NULL
);

CREATE TABLE detail_transaksi (
    id_detailtransaksi SERIAL PRIMARY KEY,
    jumlah INT NOT NULL,
    id_transaksi INT,
    id_produk INT,
    CONSTRAINT fk_detail_transaksi_transaksi FOREIGN KEY (id_transaksi)
        REFERENCES transaksi(id_transaksi)
        ON DELETE CASCADE,
    CONSTRAINT fk_detail_transaksi_produk FOREIGN KEY (id_produk)
        REFERENCES produk(id_produk)
        ON DELETE SET NULL
);

CREATE TABLE feedback (
    id_feedback SERIAL PRIMARY KEY,
    tanggal_feedback DATE NOT NULL,
    pertanyaan TEXT NOT NULL,
    respon TEXT,
    id_user INT,
    CONSTRAINT fk_feedback_user FOREIGN KEY (id_user)
        REFERENCES users(id_user)
        ON DELETE SET NULL
);

INSERT INTO users (username, password, nama_lengkap, no_telp, is_admin)
VALUES ('admin', 'admin123', '-', '-', TRUE);

INSERT INTO kategori (nama_kategori)
VALUES ('Obat Tanaman'), ('Pupuk');

select * from kategori


DROP SCHEMA public CASCADE;
CREATE SCHEMA public;

SELECT * FROM users

