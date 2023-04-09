create database QLBENHVIEN;
use QLBENHVIEN;

drop table if exists DICHVU;
drop table if exists LOAIDICHVU;
drop table if exists NHANVIEN;
drop table if exists BENHNHAN;
drop table if exists BACSI;
drop table if exists KETQUAKHAM;
drop table if exists BANKE;
drop table if exists BANGTONGHOP;
drop table if exists PHIEUTHUTIENTHU;

create table BENHNHAN(
	mabn int identity(1,1) primary key,
	hoten nchar(100),
	gioitinh nchar(5),
	ngaysinh date,
	diachi nchar(100),
	doituong nchar(15)
);

create table NHANVIEN(
	manv nchar(10) primary key,
	hoten nchar(100),
	chucvu nchar(100)
);

create table BACSI(
	mabs nchar(10) primary key,
	hoten nchar(100),
	trinhdo nchar(100),
	chuyenmon nchar(100),
	chucvu nchar(100),
	tenphongkham nchar(100)
);

create table LOAIDICHVU(
	maloaidv nchar(10) primary key,
	tenloaidv nchar(100)
);

create table DICHVU(
	madv nchar(10) primary key,
	maloaidv nchar(10) foreign key references LOAIDICHVU(maloaidv),
	tendv nchar(100),
	gia float,
	donvi nchar(10),
	ghichu nchar(500)
);

create table BANKE(
	masobk nchar(15) primary key,
	madv nchar(10) foreign key references DICHVU(madv),
	mabn int foreign key references BENHNHAN(mabn),
	manv nchar(10) foreign key references NHANVIEN(manv),
	soba nchar(15),
	soluong int,
	phuthu float,
	ngaylapbk date
);

create table KETQUAKHAM(
	mabs nchar(10) foreign key references BACSI(mabs),
	mabn int foreign key references BENHNHAN(mabn),
	madv nchar(10) foreign key references DICHVU(madv),
	masobk nchar(15) foreign key references BANKE(masobk),
	ngaytb date,
	ketqua nchar(500),

);

create table BANGTONGHOP(
	mabn int foreign key references BENHNHAN(mabn),
	manv nchar(10) foreign key references NHANVIEN(manv),
	madv nchar(10) foreign key references DICHVU(madv),
	soluong int,
	sotienbhtt float,
	ngayttoan date
);

create table PHIEUTHUTIENTU(
	maphieutttu nchar(10) primary key,
	mabn int foreign key references BENHNHAN(mabn),
	manv nchar(10) foreign key references NHANVIEN(manv),
	madv nchar(10) foreign key references DICHVU(madv),
	soba nchar(15),
	khoa nchar(100),
	sotiennop float,
	ngaythutientu date
);

insert into BENHNHAN(hoten, gioitinh, ngaysinh, diachi, doituong)
values
(N'Trần Văn Anh', N'Nữ', '1974/1/23', N'Đội 4 - Tú Sơn - Kiến Thụy - Hải Phòng', N'Dịch vụ'),
(N'Hoàng Thị Tâm', N'Nữ', '1990/1/12', N'Mỹ Đồng - Thủy Nguyên - Hải Phòng', N'Dịch vụ'),
(N'Nguyễn Thị Phương', N'Nữ', '1987/5/19', N'Đồng Tâm - Hai Bà Trưng - Hà Nội', 'BHYT'),
(N'Mai Ánh Tuyết', N'Nữ', '1991/12/23', N'Việt Trì - Phú Thọ', N'Dịch vụ'),
(N'Phan Tuyết My', N'Nữ', '1999/1/12', N'Uông Bí - Quảng Ninh', 'BHYT');

insert into NHANVIEN(manv, hoten, chucvu)
values
('NV0001', N'Trần Hải Anh', N'Kế toán viện phí'),
('NV0002', N'Nguyễn Hải Yến', N'Kế toán viện phí'),
('NV0003', N'Hoàng Tâm Như', N'Kế toán viện phí'),
('NV0004', N'Phan Thùy Linh', N'Kế toán viện phí'),
('NV0005', N'Nguyễn Khả Ái', N'Kế toán viện phí');

insert into BACSI(mabs, hoten, trinhdo, chuyenmon, chucvu, tenphongkham)
values
('BS001', N'Trần Lan Anh', N'Bác sĩ đa khoa II', N'Sản khoa, phụ khoa', N'Trưởng khoa', N'Phụ sản - điều trị'),
('BS002', N'Nguyễn Thị Phương', N'Bác sĩ đa khoa II', N'Sản khoa', N'Phó trưởng khoa', N'Phụ sản - điều trị'),
('BS003', N'Hoàng Thị Mai Lan', N'Bác sĩ đa khoa II', N'Phụ khoa', N'Phó trưởng khoa', N'Phụ sản - điều trị'),
('BS004', N'Ngô Bảo Tân', N'Bác sĩ đa khoa I', N'Kế hoạch hóa gia đình', N'Điều dưỡng trưởng khoa', N'Phụ sản - điều trị');

insert into LOAIDICHVU(maloaidv, tenloaidv)
values
('LDV001', N'Chăm sóc theo yêu cầu của bệnh nhân'),
('LDV002', N'Điều trị đẻ và phấu thuật'),
('LDV003', N'Kế hoạch hóa gia đình'),
('LDV004', N'Chuẩn đoán hình ảnh và thăm dò chức năng'),
('LDV005', N'Xét nghiệm thăm dò chuẩn đoán');

insert into DICHVU(madv, maloaidv, tendv, gia, donvi, ghichu)
values
('DV001', 'LDV001', N'Khám quản lý thai trọn gói', 5000000, N'lần', N'Không'),
('DV002', 'LDV001', N'Kiểm tra sức khỏe tiền hôn nhân', 500000, N'lần', N'Không'),
('DV003', 'LDV002', N'Yêu cầu bác sĩ mổ đẻ', 11250000, N'lần', N'Không'),
('DV004', 'LDV004', N'Siêu âm thường', 150000, N'lần', N'Không'),
('DV005', 'LDV004', N'Siêu âm 3D-4D', 300000, N'lần', N'Không'),
('DV006', 'LDV001', N'Người nhà ở lại', 100000, N'lần', N'Không');

insert into BANKE(masobk, madv, mabn, manv, soba, soluong, phuthu, ngaylapbk)
values
('BK001', 'DV001', 1, 'NV0001', '2022-100001', 1, 0, '2022/12/4'),
('BK002', 'DV003', 1, 'NV0002', '2023-100001', 1, 0, '2023/1/4'),
('BK003', 'DV002', 2, 'NV0003', '2023-100002', 1, 0, '2023/2/23');

insert into KETQUAKHAM(mabs, mabn, madv, masobk, ketqua, ngaytb)
values
('BS001', 1, 'DV001', 'BK001', N'Thai phát triển bình thường', '2022/12/4'),
('BS002', 1, 'DV003', 'BK002', N'Sau đẻ thường ngày thứ 4 ổn định', '2023/1/4'),
('BS003', 2, 'DV002', 'BK003', N'Sức khỏe ổn định', '2023/2/23');

insert into PHIEUTHUTIENTU(maphieutttu, mabn, manv, madv, soba, khoa, sotiennop, ngaythutientu)
values
('PT0001', 1, 'NV0002', 'DV003', '2023-100001', N'Phụ sản - điều trị', 11250000, '2023/1/4'),
('PT0002', 2, 'NV0004', 'DV002', '2023-100002', N'Phụ sản - điều trị', 500000, '2023/2/23');

insert into BANGTONGHOP(mabn, manv, madv, soluong, sotienbhtt, ngayttoan)
values
(1, 'NV0001', 'DV003', 1, 0, '2023/1/4'),
(2, 'NV0004', 'DV006', 1, 0, '2023/2/23'),
(3, 'NV0002', 'DV005', 1, 300000, '2023/6/2');