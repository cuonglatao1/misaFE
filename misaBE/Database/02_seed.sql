USE misa_salary;

-- Đơn vị công tác
INSERT INTO pa_organization (OrganizationId, OrganizationCode, OrganizationName, Status, CreatedBy) VALUES
('ORG-00000000-0000-0000-0000-000000000001', 'MISA', 'MISA Test pdthien 2024', 1, 'system'),
('ORG-00000000-0000-0000-0000-000000000002', 'PB_KT', 'Phòng ban Kế toán', 1, 'system'),
('ORG-00000000-0000-0000-0000-000000000003', 'PB_IT', 'Phòng ban Công nghệ thông tin', 1, 'system'),
('ORG-00000000-0000-0000-0000-000000000004', 'PB_HC', 'Phòng ban Hành chính', 1, 'system'),
('ORG-00000000-0000-0000-0000-000000000005', 'PB_KD', 'Phòng ban Kinh doanh', 1, 'system');

-- Danh mục hệ thống
INSERT INTO pa_salary_composition_system (
    SalaryCompositionSystemId, SalaryCompositionCode, SalaryCompositionName,
    SalaryComponentType, Nature, TaxOption, ValueType, Description, Status, CreatedBy
) VALUES
('SYS-00000000-0000-0000-0000-000000000001', 'LUONG_CO_BAN', 'Lương cơ bản', 1, 1, 1, 1, 'Lương cơ bản theo hợp đồng lao động', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000002', 'LUONG_KINH_DOANH', 'Lương kinh doanh', 1, 1, 1, 1, 'Lương dành cho nhân viên kinh doanh', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000003', 'PHU_CAP_CHUC_VU', 'Phụ cấp chức vụ', 1, 1, 1, 1, 'Phụ cấp theo chức vụ quản lý', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000004', 'PHU_CAP_DIEN_THOAI', 'Phụ cấp điện thoại', 1, 1, 2, 1, 'Phụ cấp chi phí điện thoại hàng tháng', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000005', 'PHU_CAP_AN_TRUA', 'Phụ cấp ăn trưa', 1, 1, 2, 1, 'Phụ cấp ăn trưa hàng ngày', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000006', 'THUONG_DOANH_SO', 'Thưởng doanh số', 1, 2, 1, 1, 'Thưởng theo doanh số đạt được', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000007', 'THUONG_HIEU_SUAT', 'Thưởng hiệu suất', 1, 2, 1, 1, 'Thưởng theo KPI hiệu suất làm việc', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000008', 'THUONG_THANG_13', 'Thưởng tháng 13', 1, 3, 1, 1, 'Lương tháng 13 cuối năm', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000009', 'BHXH_NLD', 'BHXH nhân viên đóng', 2, 1, 2, 3, 'Bảo hiểm xã hội phần nhân viên đóng (8%)', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000010', 'BHYT_NLD', 'BHYT nhân viên đóng', 2, 1, 2, 3, 'Bảo hiểm y tế phần nhân viên đóng (1.5%)', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000011', 'BHTN_NLD', 'BHTN nhân viên đóng', 2, 1, 2, 3, 'Bảo hiểm thất nghiệp phần nhân viên đóng (1%)', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000012', 'THUE_TNCN', 'Thuế thu nhập cá nhân', 2, 3, 1, 1, 'Thuế TNCN tính theo biểu thuế lũy tiến', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000013', 'SO_NGAY_CONG', 'Số ngày công', 3, 2, 2, 2, 'Số ngày làm việc thực tế trong tháng', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000014', 'SO_GIO_LAM_THEM', 'Số giờ làm thêm', 3, 2, 2, 2, 'Tổng số giờ làm thêm trong tháng', 1, 'system'),
('SYS-00000000-0000-0000-0000-000000000015', 'DOANH_SO_THANG', 'Doanh số tháng', 4, 2, 2, 1, 'Doanh số bán hàng trong tháng', 1, 'system');

-- Thành phần lương mẫu
INSERT INTO pa_salary_composition (
    SalaryCompositionId, SalaryCompositionCode, SalaryCompositionName,
    OrganizationId, SalaryComponentType, Nature, TaxOption,
    ValueType, ValueSource, ShowOnPayslip, SourceType,
    SalaryCompositionSystemId, Status, CreatedBy
) VALUES
('SC-000000000-0000-0000-0000-000000000001', 'LUONG_CO_BAN', 'Lương cơ bản',
 'ORG-00000000-0000-0000-0000-000000000001', 1, 1, 1, 1, 2, 1, 2,
 'SYS-00000000-0000-0000-0000-000000000001', 1, 'admin'),
('SC-000000000-0000-0000-0000-000000000002', 'PHU_CAP_CHUC_VU', 'Phụ cấp chức vụ',
 'ORG-00000000-0000-0000-0000-000000000001', 1, 1, 1, 1, 2, 1, 2,
 'SYS-00000000-0000-0000-0000-000000000003', 1, 'admin'),
('SC-000000000-0000-0000-0000-000000000003', 'BHXH_NLD', 'BHXH nhân viên đóng',
 'ORG-00000000-0000-0000-0000-000000000001', 2, 1, 2, 3, 2, 1, 2,
 'SYS-00000000-0000-0000-0000-000000000009', 1, 'admin'),
('SC-000000000-0000-0000-0000-000000000004', 'THUE_TNCN', 'Thuế thu nhập cá nhân',
 NULL, 2, 3, 1, 1, 2, 1, 2,
 'SYS-00000000-0000-0000-0000-000000000012', 1, 'admin'),
('SC-000000000-0000-0000-0000-000000000005', 'PCCV_IT', 'Phụ cấp chuyên môn IT',
 'ORG-00000000-0000-0000-0000-000000000003', 1, 1, 2, 1, 2, 1, 1,
 NULL, 1, 'admin');

-- Cấu hình cột mặc định
INSERT INTO pa_grid_config (GridConfigId, GridId, ColumnName, ColumnTitle, Width, Visible, Pinned, OrderIndex) VALUES
('GC-00000000-0000-0000-0000-000000000001', 'salary_composition', 'SalaryCompositionCode', 'Mã thành phần', 150, 1, 1, 1),
('GC-00000000-0000-0000-0000-000000000002', 'salary_composition', 'SalaryCompositionName', 'Tên thành phần', 250, 1, 0, 2),
('GC-00000000-0000-0000-0000-000000000003', 'salary_composition', 'SalaryComponentType', 'Loại thành phần', 140, 1, 0, 3),
('GC-00000000-0000-0000-0000-000000000004', 'salary_composition', 'Nature', 'Tính chất', 130, 1, 0, 4),
('GC-00000000-0000-0000-0000-000000000005', 'salary_composition', 'OrganizationName', 'Đơn vị công tác', 200, 1, 0, 5),
('GC-00000000-0000-0000-0000-000000000006', 'salary_composition', 'Status', 'Trạng thái', 120, 1, 0, 6),
('GC-00000000-0000-0000-0000-000000000007', 'salary_composition', 'CreatedDate', 'Ngày tạo', 140, 0, 0, 7),
('GC-00000000-0000-0000-0000-000000000011', 'salary_composition_system', 'SalaryCompositionCode', 'Mã thành phần', 150, 1, 1, 1),
('GC-00000000-0000-0000-0000-000000000012', 'salary_composition_system', 'SalaryCompositionName', 'Tên thành phần', 250, 1, 0, 2),
('GC-00000000-0000-0000-0000-000000000013', 'salary_composition_system', 'SalaryComponentType', 'Loại thành phần', 140, 1, 0, 3),
('GC-00000000-0000-0000-0000-000000000014', 'salary_composition_system', 'Nature', 'Tính chất', 130, 1, 0, 4),
('GC-00000000-0000-0000-0000-000000000015', 'salary_composition_system', 'Status', 'Trạng thái', 120, 1, 0, 5);
