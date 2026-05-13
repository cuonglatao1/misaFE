-- ============================================================
-- MISA Salary Database Schema
-- Database: misa_salary | Engine: MySQL 8.0+
-- ============================================================

CREATE DATABASE IF NOT EXISTS misa_salary
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE misa_salary;

-- Đơn vị công tác
CREATE TABLE IF NOT EXISTS pa_organization (
    OrganizationId    CHAR(36)     NOT NULL DEFAULT (UUID()),
    OrganizationCode  VARCHAR(50)  NOT NULL,
    OrganizationName  VARCHAR(255) NOT NULL,
    ParentId          CHAR(36)     NULL,
    Status            TINYINT      NOT NULL DEFAULT 1 COMMENT '1=Đang hoạt động, 0=Ngừng',
    CreatedDate       DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CreatedBy         VARCHAR(255) NULL,
    ModifiedDate      DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    ModifiedBy        VARCHAR(255) NULL,
    PRIMARY KEY (OrganizationId),
    UNIQUE KEY uq_org_code (OrganizationCode),
    KEY idx_org_parent (ParentId),
    KEY idx_org_status (Status)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Danh sách đơn vị công tác';

-- Danh mục thành phần lương hệ thống
CREATE TABLE IF NOT EXISTS pa_salary_composition_system (
    SalaryCompositionSystemId CHAR(36)     NOT NULL DEFAULT (UUID()),
    SalaryCompositionCode     VARCHAR(255) NOT NULL,
    SalaryCompositionName     VARCHAR(255) NOT NULL,
    SalaryComponentType       TINYINT      NOT NULL COMMENT '1=Thu nhập,2=Khấu trừ,3=Chấm công,4=Doanh số,5=Thông tin NV,6=Khác',
    Nature                    TINYINT      NOT NULL COMMENT '1=Cố định,2=Biến đổi,3=Theo công thức',
    TaxOption                 TINYINT      NOT NULL DEFAULT 1 COMMENT '1=Chịu thuế,2=Miễn toàn phần,3=Miễn một phần',
    ValueType                 TINYINT      NOT NULL DEFAULT 1 COMMENT '1=Tiền tệ,2=Số,3=Phần trăm,4=Chữ',
    Description               TEXT         NULL,
    Status                    TINYINT      NOT NULL DEFAULT 1 COMMENT '1=Đang theo dõi,0=Ngừng theo dõi',
    CreatedDate               DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CreatedBy                 VARCHAR(255) NULL,
    ModifiedDate              DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    ModifiedBy                VARCHAR(255) NULL,
    PRIMARY KEY (SalaryCompositionSystemId),
    UNIQUE KEY uq_sys_code (SalaryCompositionCode),
    KEY idx_sys_type (SalaryComponentType),
    KEY idx_sys_status (Status)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Danh mục thành phần lương của hệ thống';

-- Thành phần lương
CREATE TABLE IF NOT EXISTS pa_salary_composition (
    SalaryCompositionId       CHAR(36)     NOT NULL DEFAULT (UUID()),
    SalaryCompositionCode     VARCHAR(255) NOT NULL,
    SalaryCompositionName     VARCHAR(255) NOT NULL,
    OrganizationId            CHAR(36)     NULL,
    SalaryComponentType       TINYINT      NOT NULL COMMENT '1=Thu nhập,2=Khấu trừ,3=Chấm công,4=Doanh số,5=Thông tin NV,6=Khác',
    Nature                    TINYINT      NOT NULL COMMENT '1=Cố định,2=Biến đổi,3=Theo công thức',
    TaxOption                 TINYINT      NOT NULL DEFAULT 1 COMMENT '1=Chịu thuế,2=Miễn toàn phần,3=Miễn một phần',
    Quota                     TEXT         NULL COMMENT 'Công thức định mức',
    AllowManualOverride       TINYINT(1)   NOT NULL DEFAULT 0,
    ValueType                 TINYINT      NOT NULL DEFAULT 1 COMMENT '1=Tiền tệ,2=Số,3=Phần trăm,4=Chữ',
    ValueSource               TINYINT      NOT NULL DEFAULT 2 COMMENT '1=Tự động,2=Theo công thức',
    ValueFormula              TEXT         NULL,
    Description               TEXT         NULL,
    ShowOnPayslip             TINYINT      NOT NULL DEFAULT 2 COMMENT '1=Có,2=Không,3=Chỉ nếu khác 0',
    SourceType                TINYINT      NOT NULL DEFAULT 1 COMMENT '1=Tự thêm,2=Từ hệ thống',
    SalaryCompositionSystemId CHAR(36)     NULL,
    Status                    TINYINT      NOT NULL DEFAULT 1 COMMENT '1=Đang theo dõi,0=Ngừng theo dõi',
    CreatedDate               DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CreatedBy                 VARCHAR(255) NULL,
    ModifiedDate              DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    ModifiedBy                VARCHAR(255) NULL,
    PRIMARY KEY (SalaryCompositionId),
    UNIQUE KEY uq_sc_code (SalaryCompositionCode),
    KEY idx_sc_org (OrganizationId),
    KEY idx_sc_type (SalaryComponentType),
    KEY idx_sc_status (Status),
    CONSTRAINT fk_sc_org FOREIGN KEY (OrganizationId)
        REFERENCES pa_organization (OrganizationId) ON DELETE SET NULL,
    CONSTRAINT fk_sc_system FOREIGN KEY (SalaryCompositionSystemId)
        REFERENCES pa_salary_composition_system (SalaryCompositionSystemId) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Danh sách thành phần lương';

-- Cấu hình cột lưới
CREATE TABLE IF NOT EXISTS pa_grid_config (
    GridConfigId CHAR(36)     NOT NULL DEFAULT (UUID()),
    GridId       VARCHAR(100) NOT NULL COMMENT 'Định danh lưới',
    ColumnName   VARCHAR(100) NOT NULL,
    ColumnTitle  VARCHAR(255) NOT NULL,
    Width        INT          NOT NULL DEFAULT 120,
    Visible      TINYINT(1)   NOT NULL DEFAULT 1,
    Pinned       TINYINT(1)   NOT NULL DEFAULT 0,
    OrderIndex   INT          NOT NULL DEFAULT 0,
    UserId       VARCHAR(255) NULL COMMENT 'NULL = cấu hình mặc định',
    CreatedDate  DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
    ModifiedDate DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (GridConfigId),
    KEY idx_gc_grid (GridId),
    KEY idx_gc_user (UserId)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Cấu hình hiển thị cột trong các lưới dữ liệu';
