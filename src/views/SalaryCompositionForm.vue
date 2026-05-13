<template>
  <div class="h-full container" style="padding: 16px 24px">
    <!-- Notify template -->
    <div class="notify-template-root"></div>

    <!-- Header -->
    <div class="content-header p-b-16">
      <div class="flex justify-between items-center">
        <div class="flex items-center">
          <div class="ms-icon-container flex items-center justify-center m-r-8 btn-icon-back" @click="handleBack">
            <i class="ms-icon mi-arrow-left"></i>
          </div>
          <h2 class="m-r-8">{{ pageTitle }}</h2>
        </div>

        <div class="flex items-center" style="gap: 8px; flex-wrap: nowrap">
          <button class="btn-secondary" @click="handleCancel" style="width: 80px; white-space: nowrap">Hủy bỏ</button>
          <button v-if="isAddMode" class="btn-secondary" @click="handleSaveAndAdd" style="width: 106px; white-space: nowrap">Lưu và thêm</button>
          <button class="btn-primary" @click="handleSave" style="width: 80px; white-space: nowrap">Lưu</button>
        </div>
      </div>
    </div>

    <!-- Content -->
    <div id="content-main-id" class="content-main" style="background: white; height: calc(100vh - 132px); padding: 24px; overflow-y: auto">
      <div class="form-container">
        <!-- Tên thành phần -->
        <div class="form-group">
          <label class="form-label required">Tên thành phần</label>
          <input v-model="formData.name" type="text" class="form-input" placeholder="" style="width: 676px; flex: none" />
        </div>

        <!-- Mã thành phần -->
        <div class="form-group">
          <label class="form-label required">Mã thành phần</label>
          <input v-model="formData.code" type="text" class="form-input" placeholder="Nhập mã viết liền" style="width: 676px; flex: none" />
        </div>

        <!-- Đơn vị áp dụng -->
        <div class="form-group">
          <label class="form-label">Đơn vị áp dụng</label>
          <div class="select-wrapper" style="width: 676px; flex: none">
            <select v-model="formData.organizationUnit" class="form-select">
              <option value="">Misa Test pdthien 2024</option>
              <option value="unit1">Đơn vị 1</option>
              <option value="unit2">Đơn vị 2</option>
            </select>
          </div>
        </div>

        <!-- Loại thành phần -->
        <div class="form-group">
          <label class="form-label required">Loại thành phần</label>
          <div class="select-wrapper" style="width: 237px; flex: none">
            <select v-model="formData.type" class="form-select">
              <option value="">Chọn loại thành phần</option>
              <option value="income">Thu nhập</option>
              <option value="deduction">Khấu trừ</option>
              <option value="attendance">Chấm công</option>
              <option value="sales">Doanh số</option>
              <option value="employee">Thông tin nhân viên</option>
              <option value="other">Khác</option>
            </select>
          </div>
        </div>

        <!-- Tính chất -->
        <div class="form-group" style="flex-wrap: nowrap">
          <label class="form-label required">Tính chất</label>
          <div style="flex: 1; display: flex; align-items: center; gap: 16px; flex-wrap: nowrap">
            <div class="select-wrapper" style="width: 237px; flex: none">
              <select v-model="formData.nature" class="form-select">
                <option value="income">Thu nhập</option>
                <option value="fixed">Cố định</option>
                <option value="variable">Biến đổi</option>
                <option value="formula">Theo công thức</option>
              </select>
            </div>
            <div class="radio-group" style="flex-wrap: nowrap; white-space: nowrap">
              <label class="radio-label" style="white-space: nowrap">
                <input v-model="formData.taxOption" type="radio" value="subject" name="taxOption" />
                <span class="radio-text">Chịu thuế</span>
              </label>
              <label class="radio-label" style="white-space: nowrap">
                <input v-model="formData.taxOption" type="radio" value="exempt_full" name="taxOption" />
                <span class="radio-text">Miễn thuế toàn phần</span>
              </label>
              <label class="radio-label" style="white-space: nowrap">
                <input v-model="formData.taxOption" type="radio" value="exempt_partial" name="taxOption" />
                <span class="radio-text">Miễn thuế một phần</span>
              </label>
            </div>
          </div>
        </div>

        <!-- Định mức -->
        <div class="form-group">
          <label class="form-label">Định mức</label>
          <div style="flex: 1">
            <textarea v-model="formData.quota" class="form-textarea" placeholder="Tự động gọi ý công thức và tham số khi gõ" style="width: 676px; flex: none"></textarea>
            <div class="form-checkbox m-t-8">
              <input v-model="formData.allowManualOverride" type="checkbox" id="allowManualOverride" class="custom-checkbox" />
              <label for="allowManualOverride" class="checkbox-label">Cho phép giá trị tính vượt quá định mức</label>
            </div>
          </div>
        </div>

        <!-- Kiểu giá trị -->
        <div class="form-group">
          <label class="form-label required">Kiểu giá trị</label>
          <div class="select-wrapper" style="width: 237px; flex: none">
            <select v-model="formData.valueType" class="form-select form-select-readonly" disabled>
              <option value="money">Tiền tệ</option>
              <option value="number">Số</option>
              <option value="percent">Phần trăm</option>
              <option value="text">Chữ</option>
            </select>
          </div>
        </div>

        <!-- Giá trị -->
        <div class="form-group" style="align-items: flex-start">
          <label class="form-label">Giá trị</label>
          <div style="flex: 1">
            <div class="radio-group" style="margin-top: 8px">
              <label class="radio-label">
                <input v-model="formData.valueSource" type="radio" value="auto" name="valueSource" />
                <span class="radio-text">Tự động cộng tổng giá trị của các nhân viên</span>
              </label>
              <div class="select-wrapper-with-icon m-l-24">
                <select class="form-select-with-icon" disabled>
                  <option>Trong cùng đơn vị công tác</option>
                </select>
                <span class="info-icon">i</span>
              </div>
            </div>
            <div class="radio-group m-t-8" style="margin-bottom: 8px">
              <label class="radio-label">
                <input v-model="formData.valueSource" type="radio" value="manual" name="valueSource" checked />
                <span class="radio-text">Tính theo công thức tự đặt</span>
              </label>
            </div>
            <textarea v-model="formData.value" class="form-textarea" placeholder="Tự động gọi ý công thức và tham số khi gõ" style="width: 676px; flex: none"></textarea>
          </div>
        </div>

        <!-- Mô tả -->
        <div class="form-group">
          <label class="form-label">Mô tả</label>
          <textarea v-model="formData.description" class="form-textarea-description" style="width: 676px; flex: none"></textarea>
        </div>

        <!-- Hiển thị trên phiếu lương -->
        <div class="form-group">
          <label class="form-label" style="white-space: nowrap">Hiển thị trên phiếu lương</label>
          <div class="radio-group" style="flex: 1; flex-wrap: nowrap">
            <label class="radio-label" style="white-space: nowrap">
              <input v-model="formData.showOnPayslip" type="radio" value="yes" name="showOnPayslip" />
              <span class="radio-text">Có</span>
            </label>
            <label class="radio-label" style="white-space: nowrap">
              <input v-model="formData.showOnPayslip" type="radio" value="no" name="showOnPayslip" />
              <span class="radio-text">Không</span>
            </label>
            <label class="radio-label" style="white-space: nowrap">
              <input v-model="formData.showOnPayslip" type="radio" value="nonzero" name="showOnPayslip" />
              <span class="radio-text">Chỉ hiển thị nếu các giá trị khác 0</span>
            </label>
          </div>
        </div>

        <!-- Nguồn tạo -->
        <div class="form-group">
          <label class="form-label">Nguồn tạo</label>
          <div style="flex: 1">
            <div class="form-static-text" style="color: #000; border-bottom: 1px solid #d9d9d9; width: 676px; padding-bottom: 8px">Tự thêm</div>
          </div>
        </div>

        <!-- Trạng thái (chỉ hiển thị ở chế độ Edit) -->
        <div v-if="isEditMode" class="form-group">
          <label class="form-label">Trạng thái</label>
          <div class="radio-group" style="flex: 1">
            <label class="radio-label">
              <input v-model="formData.status" type="radio" value="active" name="status" />
              <span class="radio-text">Đang theo dõi</span>
            </label>
            <label class="radio-label">
              <input v-model="formData.status" type="radio" value="inactive" name="status" />
              <span class="radio-text">Ngừng theo dõi</span>
            </label>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'

const router = useRouter()
const route = useRoute()

// Xác định mode: Add hay Edit
const isEditMode = computed(() => !!route.params.id)
const isAddMode = computed(() => !route.params.id)

// Title động
const pageTitle = computed(() => {
  if (isEditMode.value) {
    return formData.value.name || 'Sửa thành phần'
  }
  return 'Thêm thành phần'
})

// Form data
const formData = ref({
  name: '',
  code: '',
  organizationUnit: '',
  type: '',
  nature: 'income',
  taxOption: 'subject',
  quota: '',
  allowManualOverride: false,
  valueType: 'money',
  valueSource: 'manual',
  value: '',
  description: '',
  showOnPayslip: 'no',
  status: 'active',
})

// Load data khi Edit
onMounted(async () => {
  if (isEditMode.value) {
    const id = route.params.id
    console.log('Loading data for ID:', id)

    // TODO: Gọi API để load dữ liệu
    // const response = await api.getSalaryComposition(id)
    // formData.value = response.data

    // Mock data tạm
    formData.value = {
      name: 'Lương cơ bản',
      code: 'LUONG_CO_BAN',
      organizationUnit: '',
      type: 'income',
      nature: 'income',
      taxOption: 'subject',
      quota: '',
      allowManualOverride: false,
      valueType: 'money',
      valueSource: 'manual',
      value: '',
      description: '',
      showOnPayslip: 'yes',
      status: 'active',
    }
  }
})

// Reset form về giá trị mặc định
const resetForm = () => {
  formData.value = {
    name: '',
    code: '',
    organizationUnit: '',
    type: '',
    nature: 'income',
    taxOption: 'subject',
    quota: '',
    allowManualOverride: false,
    valueType: 'money',
    valueSource: 'manual',
    value: '',
    description: '',
    showOnPayslip: 'no',
    status: 'active',
  }
}

const handleBack = () => {
  router.back()
}

const handleCancel = () => {
  router.back()
}

const handleSave = async () => {
  console.log('Saving data:', formData.value)

  // TODO: Implement save logic
  if (isEditMode.value) {
    // await api.updateSalaryComposition(route.params.id, formData.value)
  } else {
    // await api.createSalaryComposition(formData.value)
  }

  router.back()
}

const handleSaveAndAdd = async () => {
  console.log('Saving and adding new:', formData.value)

  // TODO: Implement save logic
  // await api.createSalaryComposition(formData.value)

  // Reset form để thêm mới tiếp
  resetForm()
}
</script>

<style scoped>
.h-full {
  height: 100%;
}
.w-full {
  width: 100%;
}
.flex {
  display: flex;
}
.items-center {
  align-items: center;
}
.justify-between {
  justify-content: space-between;
}
.p-b-16 {
  padding-bottom: 16px;
}
.m-r-8 {
  margin-right: 8px;
}
.m-l-8 {
  margin-left: 8px;
}
.m-t-8 {
  margin-top: 8px;
}
.m-l-24 {
  margin-left: 24px;
}
.container {
  background: #f2f2f2;
}
.content-header h2 {
  font-size: 20.5px;
  font-weight: 700;
  color: #212121;
  margin: 0;
}

/* Buttons */
.btn-primary {
  align-items: center;
  appearance: auto;
  background-color: rgb(52, 176, 87);
  border: 0.8px solid rgb(52, 176, 87);
  border-radius: 4px;
  box-sizing: border-box;
  color: rgb(255, 255, 255);
  cursor: pointer;
  display: flex;
  gap: 5px;
  font-family: Inter, Roboto, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-weight: 500;
  height: 36px;
  justify-content: center;
  outline: none;
  padding: 0px 16px;
  text-align: center;
}
.btn-primary:hover {
  background-color: #2d9a4a;
}
.btn-secondary {
  align-items: center;
  appearance: auto;
  background-color: rgb(255, 255, 255);
  border: 0.8px solid rgb(235, 235, 235);
  border-radius: 4px;
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  cursor: pointer;
  display: flex;
  gap: 5px;
  font-family: Inter, Roboto, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-weight: 500;
  height: 36px;
  justify-content: center;
  outline: none;
  padding: 0px 16px;
  text-align: center;
}
.btn-secondary:hover {
  background-color: #f5f5f5;
}

/* Back button icon */
.btn-icon-back {
  width: 32px;
  height: 32px;
  border-radius: 50%;
  cursor: pointer;
  transition: background-color 0.2s;
}
.btn-icon-back:hover {
  background-color: #f5f5f5;
}
.mi-arrow-left {
  background-color: rgb(110, 115, 122);
  box-sizing: border-box;
  color: rgb(175, 179, 193);
  cursor: pointer;
  direction: ltr;
  display: block;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 16px;
  font-style: italic;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  height: 20px;
  letter-spacing: 0.14px;
  line-height: 24px;
  margin: 0;
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  min-height: 20px;
  min-width: 20px;
  outline: none;
  padding: 0;
  text-align: center;
  text-decoration: none;
  text-size-adjust: 100%;
  text-transform: none;
  width: 20px;
  -webkit-mask-position-x: -180px;
  -webkit-mask-position-y: 0px;
  mask-position: -180px 0px;
}
.mi-arrow-left::before {
  content: '';
}

/* Form styles */
.form-container {
  max-width: 800px;
}
.form-group {
  margin-bottom: 24px;
  display: flex;
  align-items: center;
  gap: 36px;
}
.form-label {
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  cursor: default;
  direction: ltr;
  display: block;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 700;
  height: 35px;
  letter-spacing: 0.14px;
  line-height: 35px;
  margin: 0;
  outline: none;
  padding: 0;
  text-align: left;
  text-decoration: none;
  text-indent: 0;
  text-size-adjust: 100%;
  text-transform: none;
  width: 150px;
  min-width: 150px;
  flex-shrink: 0;
}
.form-label.required::after {
  content: ' *';
  color: #ff6161;
}
.form-input,
.form-select,
.form-textarea {
  appearance: auto;
  background-color: rgb(255, 255, 255);
  border: 1px solid #d9d9d9;
  border-radius: 4px;
  box-sizing: border-box;
  color: rgb(0, 0, 0);
  cursor: text;
  direction: ltr;
  display: block;
  font-family: Inter, Roboto, Helvetica, Arial, sans-serif;
  font-feature-settings: normal;
  font-kerning: auto;
  font-language-override: normal;
  font-optical-sizing: auto;
  font-size: 14px;
  font-size-adjust: none;
  font-stretch: 100%;
  font-style: normal;
  font-variant-alternates: normal;
  font-variant-caps: normal;
  font-variant-east-asian: normal;
  font-variant-emoji: normal;
  font-variant-ligatures: normal;
  font-variant-numeric: lining-nums tabular-nums;
  font-variant-position: normal;
  font-variation-settings: normal;
  font-weight: 400;
  height: 34.4px;
  letter-spacing: normal;
  line-height: normal;
  margin: 0;
  outline: none;
  overflow: clip;
  padding: 0 12px;
  text-align: start;
  text-decoration: none;
  text-indent: 0;
  text-rendering: auto;
  text-shadow: none;
  text-size-adjust: 100%;
  text-transform: none;
  width: 100%;
  word-spacing: 0;
  -webkit-rtl-ordering: logical;
  -webkit-border-image: none;
  border-image: none;
  flex: 1;
}
.form-input:focus,
.form-select:focus,
.form-textarea:focus {
  border-color: #34b057;
}
.form-input::placeholder,
.form-textarea::placeholder {
  color: #999999;
}
.form-textarea {
  appearance: auto;
  background-attachment: scroll;
  background-clip: border-box;
  background-color: rgba(0, 0, 0, 0);
  background-image: none;
  background-origin: padding-box;
  background-position: 0% 0%;
  background-repeat: repeat;
  background-size: auto;
  border: 1px solid #d9d9d9;
  border-radius: 4px;
  box-sizing: border-box;
  color: rgb(102, 102, 102);
  column-count: auto;
  cursor: text;
  direction: ltr;
  display: block;
  font-family: Inter, Roboto, Helvetica, Arial, sans-serif;
  font-feature-settings: normal;
  font-kerning: auto;
  font-language-override: normal;
  font-optical-sizing: auto;
  font-size: 14px;
  font-size-adjust: none;
  font-stretch: 100%;
  font-style: normal;
  font-variant-alternates: normal;
  font-variant-caps: normal;
  font-variant-east-asian: normal;
  font-variant-emoji: normal;
  font-variant-ligatures: normal;
  font-variant-numeric: lining-nums tabular-nums;
  font-variant-position: normal;
  font-variation-settings: normal;
  font-weight: 400;
  height: 86px;
  letter-spacing: 0.14px;
  line-height: 18px;
  margin: 0;
  outline: none;
  overflow-wrap: break-word;
  overflow-x: hidden;
  overflow-y: hidden;
  padding: 8px 12px;
  resize: none;
  tab-size: 26.25px;
  text-align: start;
  text-decoration: none;
  text-indent: 0;
  text-rendering: auto;
  text-shadow: none;
  text-size-adjust: 100%;
  text-transform: none;
  text-wrap-mode: wrap;
  white-space-collapse: preserve;
  width: 100%;
  word-spacing: 0;
  -webkit-font-smoothing: antialiased;
  -webkit-rtl-ordering: logical;
  -webkit-text-fill-color: rgb(102, 102, 102);
  -webkit-border-image: none;
  border-image: none;
  min-height: 86px;
}
.form-textarea-description {
  appearance: auto;
  background-color: rgb(255, 255, 255);
  border: 1px solid #d9d9d9;
  border-radius: 4px;
  border-image: none;
  box-sizing: border-box;
  color: rgb(0, 0, 0);
  column-count: auto;
  cursor: text;
  direction: ltr;
  display: block;
  font-family: Inter, Roboto, Helvetica, Arial, sans-serif;
  font-feature-settings: normal;
  font-kerning: auto;
  font-language-override: normal;
  font-optical-sizing: auto;
  font-size: 14px;
  font-size-adjust: none;
  font-stretch: 100%;
  font-style: normal;
  font-variant-alternates: normal;
  font-variant-caps: normal;
  font-variant-east-asian: normal;
  font-variant-emoji: normal;
  font-variant-ligatures: normal;
  font-variant-numeric: lining-nums tabular-nums;
  font-variant-position: normal;
  font-variation-settings: normal;
  font-weight: 400;
  height: 71px;
  letter-spacing: normal;
  line-height: normal;
  margin: 0;
  outline: none;
  overflow-wrap: break-word;
  padding: 6px 0;
  resize: none;
  text-align: start;
  text-decoration: none;
  text-indent: 0;
  text-rendering: auto;
  text-shadow: none;
  text-size-adjust: 100%;
  text-transform: none;
  text-wrap-mode: wrap;
  white-space-collapse: preserve;
  width: 100%;
  word-spacing: 0;
  -webkit-rtl-ordering: logical;
  -webkit-border-image: none;
  flex: 1;
}
.select-wrapper {
  position: relative;
  flex: 1;
}
.form-select {
  align-items: center;
  background-color: rgb(255, 255, 255);
  border: 0.8px solid rgb(52, 176, 87);
  border-radius: 4px;
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  direction: ltr;
  display: flex;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  height: 36px;
  letter-spacing: 0.14px;
  line-height: 35px;
  margin: 0;
  min-height: 36px;
  min-width: 100px;
  outline: none;
  padding: 0;
  text-decoration: none;
  text-indent: 0;
  text-size-adjust: 100%;
  text-transform: none;
  unicode-bidi: isolate;
  width: 100%;
  -webkit-box-align: center;
  appearance: none;
  background-image: none;
  padding-right: 36px;
  padding-left: 12px;
  cursor: pointer;
}
.form-select-readonly {
  align-items: center;
  background-color: rgb(224, 224, 224);
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  cursor: not-allowed;
  direction: ltr;
  display: flex;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  height: 36px;
  letter-spacing: 0.14px;
  line-height: 35px;
  margin: 0;
  outline: none;
  padding: 0 12px 0 10px;
  text-decoration: none;
  text-indent: 0;
  text-size-adjust: 100%;
  text-transform: none;
  unicode-bidi: isolate;
  width: 237px;
  -webkit-box-align: center;
  pointer-events: none;
}
.select-wrapper::after {
  content: '';
  position: absolute;
  right: 12px;
  top: 50%;
  transform: translateY(-50%) rotate(90deg);
  width: 20px;
  height: 20px;
  background-color: rgb(110, 115, 122);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -140px;
  -webkit-mask-position-y: 0px;
  mask-position: -140px 0px;
  pointer-events: none;
}

/* Select with info icon */
.select-wrapper-with-icon {
  position: relative;
  display: inline-flex;
  align-items: center;
}

.form-select-with-icon {
  align-items: center;
  background-color: rgb(224, 224, 224);
  border: 0.8px solid rgb(217, 217, 217);
  border-radius: 4px;
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  direction: ltr;
  display: flex;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  height: 36px;
  letter-spacing: 0.14px;
  line-height: 35px;
  margin: 0;
  outline: none;
  padding: 0 30px 0 12px;
  text-decoration: none;
  text-indent: 0;
  text-size-adjust: 100%;
  text-transform: none;
  unicode-bidi: isolate;
  width: 255.925px;
  -webkit-box-align: center;
  appearance: none;
  cursor: not-allowed;
  pointer-events: none;
}

.info-icon {
  position: absolute;
  left: calc(100% - 50px);
  top: 50%;
  transform: translateY(-50%);
  width: 16px;
  height: 16px;
  background-color: rgb(33, 150, 243);
  color: white;
  border-radius: 50%;
  display: inline-flex;
  align-items: center;
  justify-content: center;
  font-size: 11px;
  font-weight: 700;
  font-style: italic;
  font-family: Georgia, serif;
  pointer-events: none;
  margin-left: 8px;
}

.select-wrapper-with-icon::after {
  content: '';
  position: absolute;
  right: 8px;
  top: 50%;
  transform: translateY(-50%) rotate(90deg);
  width: 20px;
  height: 20px;
  background-color: rgb(110, 115, 122);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -140px;
  -webkit-mask-position-y: 0px;
  mask-position: -140px 0px;
  pointer-events: none;
}

/* Radio buttons */
.radio-group {
  display: flex;
  align-items: center;
  gap: 24px;
  flex-wrap: wrap;
}
.radio-label {
  display: flex;
  align-items: center;
  cursor: pointer;
  font-size: 14px;
  color: #212121;
  font-family: Inter, Helvetica, Arial, sans-serif;
}
.radio-label input[type='radio'] {
  width: 16px;
  height: 16px;
  margin: 0;
  margin-right: 8px;
  cursor: pointer;
  accent-color: #34b057;
}
.radio-text {
  user-select: none;
}

/* Checkboxes */
.form-checkbox {
  display: flex;
  align-items: center;
}
.custom-checkbox {
  width: 16px;
  height: 16px;
  margin: 0;
  margin-right: 8px;
  cursor: pointer;
  accent-color: #34b057;
}
.checkbox-label {
  font-size: 14px;
  color: #212121;
  cursor: pointer;
  user-select: none;
  font-family: Inter, Helvetica, Arial, sans-serif;
}

/* Static text */
.form-static-text {
  font-size: 14px;
  color: #666666;
  padding: 8px 0;
  font-family: Inter, Helvetica, Arial, sans-serif;
}

/* Scrollbar */
.content-main::-webkit-scrollbar {
  width: 8px;
}
.content-main::-webkit-scrollbar-track {
  background-color: rgba(0, 0, 0, 0);
}
.content-main::-webkit-scrollbar-thumb {
  background-color: rgb(158, 158, 158);
  border-radius: 10px;
}
.content-main::-webkit-scrollbar-thumb:hover {
  background-color: rgb(120, 120, 120);
}
</style>
