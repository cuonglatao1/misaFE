<template>
  <header class="ms-navbar--header">
    <div class="flex items-center">
      <h3 class="ms-navbar--title flex items-center">
        <!-- App Menu Icon -->
        <div id="AMIS_Launcher" class="box-app-menu flex items-center justify-center">
          <div class="tooltip-container">
            <div class="con-ms-tooltip">
              <div class="mi-ninedot"></div>
            </div>
          </div>
        </div>

        <!-- Logo -->
        <a href="/" class="router-link-active">
          <div class="logo flex items-center">
            <div class="logo-img">
              <img
                src="https://testcdnamisapp.misacdn.net/apps/payroll/static/logos/icon-payroll-logo.svg?v="
                alt="logo"
                width="32"
                height="32"
              />
            </div>
            <span class="logo-text">Tiền lương</span>
          </div>
        </a>
      </h3>

      <!-- Search Bar -->
      <div id="search-navbar" class="p-relative p-0 flex items-center">
        <div class="search-bar p-relative">
          <div class="search-container">
            <div title="Tìm kiếm" style="height: 32px; width: 300px">
              <div class="flex items-center w-full h-full">
                <div class="ms-input flex w-full">
                  <div class="ms-icon-default flex items-center justify-center p-l-8 ms-icon-">
                    <i class="ms-icon notranslate icon-scale mi-search"></i>
                  </div>
                  <input
                    maxlength="255"
                    placeholder="Tìm kiếm"
                    tabindex="1"
                    autocomplete="on"
                    type="text"
                    class="ms-input-item"
                    v-model="searchText"
                  />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Right Icons Section -->
    <div class="header-right-icons flex items-center">
      <!-- Icon 1: Store -->
      <div class="header-icon icon-store"></div>

      <!-- Icon 2: Agent Avatar -->
      <div class="header-icon-wrapper">
        <div class="header-icon icon-agent"></div>
      </div>

      <!-- Icon 3: Sprite Icon -->
      <div class="header-icon icon-sprite"></div>

      <!-- Icon 4: Add User -->
      <div class="header-icon icon-add-user"></div>

      <!-- Icon 5: Chat -->
      <div class="header-icon icon-chat"></div>

      <!-- Icon 6: Notification Bell -->
      <div class="header-icon icon-notification"></div>

      <!-- Icon 7: Help -->
      <div class="header-icon icon-help"></div>

      <!-- Icon 8: Menu Dots -->
      <div class="header-icon icon-menu-dots"></div>

      <!-- Icon 9: Lightbulb -->
      <div class="header-icon icon-lightbulb"></div>

      <!-- Avatar -->
      <img
        src="https://testcdnamisapp.misacdn.net/apps/payroll/static/img/payroll_agent.86d4797.png"
        alt="User Avatar"
        class="header-avatar"
      />
    </div>
  </header>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const searchText = ref('')
</script>

<style scoped>
.ms-navbar--header {
  height: 48px;
  background-color: #fff;
  border-bottom: 1px solid #e0e0e0;
  width: 100%;
  z-index: 100;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0;
}

.flex {
  display: flex;
}

.items-center {
  align-items: center;
}

.justify-center {
  justify-content: center;
}

.p-relative {
  position: relative;
}

.p-0 {
  padding: 0;
}

.p-l-8 {
  padding-left: 8px;
}

.w-full {
  width: 100%;
}

.h-full {
  height: 100%;
}

/* Title & Logo */
.ms-navbar--title {
  gap: 8px;
  margin: 0;
  margin-left: 16px;
  font-size: 16px;
  font-weight: 500;
}

/* App Menu Icon */
.box-app-menu {
  width: 32px;
  height: 32px;
  cursor: pointer;
  border-radius: 4px;
  transition: background-color 0.2s;
}

.box-app-menu:hover {
  background-color: #f5f5f5;
}

.mi-ninedot {
  width: 20px;
  height: 20px;
  background-color: rgb(110, 115, 122);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -80px;
  -webkit-mask-position-y: -80px;
  mask-position: -80px -80px;
  cursor: pointer;
}

/* Logo */
.logo {
  gap: 8px;
  text-decoration: none;
  color: inherit;
  padding: 4px 8px;
  border-radius: 4px;
  transition: background-color 0.2s;
}

.logo:hover {
  background-color: #f5f5f5;
}

.logo-img {
  display: flex;
  align-items: center;
}

.logo-text {
  font-size: 18px;
  font-weight: 700;
  color: rgb(0, 0, 0);
  line-height: 27px;
  height: 27px;
  margin-left: 12px;
  cursor: pointer;
  letter-spacing: 0.324px;
}

/* Search Bar */
#search-navbar {
  margin-left: 24px;
  flex: 1;
  max-width: 400px;
}

.search-bar {
  width: 300px;
}

.ms-input {
  border: none;
  border-radius: 4px;
  height: 32px;
  background-color: rgb(246, 246, 246);
  transition: all 0.2s;
}

.ms-input:hover {
  border: none;
}

.ms-input:focus-within {
  border-color: #40a9ff;
  box-shadow: 0 0 0 2px rgba(24, 144, 255, 0.2);
}

.ms-icon-default {
  color: rgb(175, 179, 193);
}

.ms-icon {
  font-size: 16px;
}

.mi-search {
  width: 20px;
  height: 20px;
  min-width: 20px;
  min-height: 20px;
  background-color: rgb(110, 115, 122);
  color: rgb(175, 179, 193);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: 0px;
  -webkit-mask-position-y: 0px;
  mask-position: 0px 0px;
  display: block;
  text-align: center;
  font-size: 16px;
  font-style: italic;
  font-weight: 400;
  line-height: 24px;
  letter-spacing: 0.14px;
}

.mi-search::before {
  content: "";
}

/* ms-input-item styles are now in global components.css */

.router-link-active {
  text-decoration: none;
}

/* Header Right Icons */
.header-right-icons {
  display: flex;
  align-items: center;
  height: 48px;
  margin-left: auto;
  margin-right: 16px;
  padding-right: 8px;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-weight: 400;
  line-height: 21px;
  letter-spacing: 0.14px;
  color: rgb(33, 33, 33);
  gap: 0;
}

.header-icon {
  width: 32px;
  height: 32px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  background-position: 50% 50%;
  background-repeat: no-repeat;
  background-size: 24px;
  margin-right: 12px;
  position: relative;
  border-radius: 16px;
  flex-shrink: 0;
}

.header-icon-wrapper {
  position: relative;
  width: 32px;
  height: 32px;
  margin-right: 12px;
  display: flex;
  align-items: center;
  justify-content: center;
}

/* Icon 1: Store */
.icon-store {
  width: 20px;
  height: 20px;
  background-image: url(https://testcdnstore.misacdn.net/lib/static/cs-icon-store.svg);
  background-size: 20px 20px;
  background-color: transparent;
}

/* Icon 2: Agent Avatar */
.icon-agent {
  width: 24px;
  height: 24px;
  background-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/payroll_agent.86d4797.png);
  background-size: cover;
  background-position: center;
  border-radius: 0;
}

/* Icon 3: Sprite Icon */
.icon-sprite {
  width: 24px;
  height: 24px;
  background-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  background-position: -336px -593px;
  background-size: auto;
}

/* Icon 4: Add User */
.icon-add-user {
  background-image: url(data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPGNpcmNsZSBjeD0iMTEuNSIgY3k9IjUuNSIgcj0iMy41IiBzdHJva2U9IiM3NTc1NzUiIHN0cm9rZS13aWR0aD0iMiIvPgo8cGF0aCBkPSJNMy41MDYyOSAxNS43NDEzTDMuMTA2NTIgMTYuMjk2NUMxLjM5MTk2IDE4LjY3NzggMy4wOTM2OCAyMiA2LjAyODA0IDIySDE1Ljk3MkMxOC45MDYzIDIyIDIwLjYwOCAxOC42Nzc4IDE4Ljg5MzUgMTYuMjk2NUwxOC40OTM3IDE1Ljc0MTNDMTYuODAyNCAxMy4zOTIyIDE0LjA4NDUgMTIgMTEuMTg5OSAxMkgxMC44MTAxQzcuOTE1NTMgMTIgNS4xOTc2MSAxMy4zOTIyIDMuNTA2MjkgMTUuNzQxM1oiIHN0cm9rZT0iIzc1NzU3NSIgc3Ryb2tlLXdpZHRoPSIyIiBzdHJva2UtbGluZWNhcD0icm91bmQiLz4KPHBhdGggZD0iTTIxIDVWN1Y5IiBzdHJva2U9IiMyQ0EwMUMiIHN0cm9rZS13aWR0aD0iMiIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIi8+CjxwYXRoIGQ9Ik0xOSA3SDIxSDIzIiBzdHJva2U9IiMyQ0EwMUMiIHN0cm9rZS13aWR0aD0iMiIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIi8+Cjwvc3ZnPgo=);
}

/* Icon 5: Chat */
.icon-chat {
  background-image: url("data:image/svg+xml,%3csvg%20width='24'%20height='24'%20viewBox='0%200%2024%2024'%20fill='none'%20xmlns='http://www.w3.org/2000/svg'%3e%3cpath%20d='M12%203C7.02944%203%203%207.02945%203%2012C3%2013.7499%203.49992%2015.3827%204.36396%2016.7645L3%2021L7.23545%2019.636C8.6173%2020.5001%2010.2501%2021%2012%2021C16.9706%2021%2021%2016.9706%2021%2012C21%207.02945%2016.9706%203%2012%203Z'%20fill='url(%23paint0_linear_5024_37369)'%20stroke='url(%23paint1_linear_5024_37369)'%20stroke-miterlimit='10'%20stroke-linecap='round'%20stroke-linejoin='round'/%3e%3cpath%20d='M13.0986%2012.0001C13.0986%2012.6069%2012.6068%2013.0988%2012%2013.0988C11.3932%2013.0988%2010.9014%2012.6069%2010.9014%2012.0001C10.9014%2011.3934%2011.3932%2010.9015%2012%2010.9015C12.6068%2010.9015%2013.0986%2011.3934%2013.0986%2012.0001Z'%20fill='white'/%3e%3cpath%20d='M17.4932%2012.0001C17.4932%2012.6069%2017.0013%2013.0988%2016.3945%2013.0988C15.7878%2013.0988%2015.2959%2012.6069%2015.2959%2012.0001C15.2959%2011.3934%2015.7878%2010.9015%2016.3945%2010.9015C17.0013%2010.9015%2017.4932%2011.3934%2017.4932%2012.0001Z'%20fill='white'/%3e%3cpath%20d='M8.7041%2012.0001C8.7041%2012.6069%208.21222%2013.0988%207.60547%2013.0988C6.99872%2013.0988%206.50684%2012.6069%206.50684%2012.0001C6.50684%2011.3934%206.99872%2010.9015%207.60547%2010.9015C8.21222%2010.9015%208.7041%2011.3934%208.7041%2012.0001Z'%20fill='white'/%3e%3cdefs%3e%3clinearGradient%20id='paint0_linear_5024_37369'%20x1='12'%20y1='3'%20x2='12'%20y2='21'%20gradientUnits='userSpaceOnUse'%3e%3cstop%20stop-color='%235B7CFF'/%3e%3cstop%20offset='1'%20stop-color='%23214BF5'/%3e%3c/linearGradient%3e%3clinearGradient%20id='paint1_linear_5024_37369'%20x1='12'%20y1='3'%20x2='12'%20y2='21'%20gradientUnits='userSpaceOnUse'%3e%3cstop%20stop-color='%235B7CFF'/%3e%3cstop%20offset='1'%20stop-color='%23214BF5'/%3e%3c/linearGradient%3e%3c/defs%3e%3c/svg%3e");
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
}

/* Icon 6: Notification Bell */
.icon-notification {
  background-image: url(data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCI+DQogIDxkZWZzPg0KICAgIDxjbGlwUGF0aCBpZD0iY2xpcC1wYXRoIj4NCiAgICAgIDxyZWN0IGlkPSJSZWN0YW5nbGVfMjIyMTUiIGRhdGEtbmFtZT0iUmVjdGFuZ2xlIDIyMjE1IiB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIGZpbGw9IiNmZmYiLz4NCiAgICA8L2NsaXBQYXRoPg0KICA8L2RlZnM+DQogIDxnIGlkPSJHcm91cF80NjI4NyIgZGF0YS1uYW1lPSJHcm91cCA0NjI4NyIgY2xpcC1wYXRoPSJ1cmwoI2NsaXAtcGF0aCkiPg0KICAgIDxwYXRoIGlkPSJQYXRoXzM2MjU3IiBkYXRhLW5hbWU9IlBhdGggMzYyNTciIGQ9Ik0xOCwxMS42VjkuM2E2LjE4NCw2LjE4NCwwLDAsMC01Ljg0Mi02LjI3NkE2LDYsMCwwLDAsNiw5LjAyNFYxMS42YzAsMi44MjgtMi41NzEsMy41MTQtMi41NzEsNS4xNDJDMy40MjksMTguMiw2Ljc3MSwxOS4zMSwxMiwxOS4zMXM4LjU3MS0xLjExNCw4LjU3MS0yLjU3MkMyMC41NzEsMTUuMTEsMTgsMTQuNDI0LDE4LDExLjZaIiBmaWxsPSJub25lIiBzdHJva2U9IiM2ZTczN2EiIHN0cm9rZS1saW5lY2FwPSJzcXVhcmUiIHN0cm9rZS1taXRlcmxpbWl0PSIxMCIgc3Ryb2tlLXdpZHRoPSIyIi8+DQogICAgPHBhdGggaWQ9IlBhdGhfMzYyNTgiIGRhdGEtbmFtZT0iUGF0aCAzNjI1OCIgZD0iTTEyLDIxLjIyOHEtMS4yNSwwLTIuNS0uMDg3YTIuNjE4LDIuNjE4LDAsMCwwLDUsMFExMy4zMjUsMjEuMjI2LDEyLDIxLjIyOFoiIGZpbGw9IiM2ZTczN2EiLz4NCiAgPC9nPg0KPC9zdmc+DQo=);
  border-radius: 50%;
}

/* Icon 7: Help */
.icon-help {
  background-image: url(data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCI+DQogIDxkZWZzPg0KICAgIDxjbGlwUGF0aCBpZD0iY2xpcC1wYXRoIj4NCiAgICAgIDxyZWN0IGlkPSJSZWN0YW5nbGVfMjgxNTkiIGRhdGEtbmFtZT0iUmVjdGFuZ2xlIDI4MTU5IiB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDQ0IDc5KSIgZmlsbD0iI2ZmZiIvPg0KICAgIDwvY2xpcFBhdGg+DQogIDwvZGVmcz4NCiAgPGcgaWQ9Ikdyb3VwXzgyNzg0IiBkYXRhLW5hbWU9Ikdyb3VwIDgyNzg0IiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgtNDY5OSAtMTcwKSI+DQogICAgPGcgaWQ9Ikdyb3VwXzgyNzc4IiBkYXRhLW5hbWU9Ikdyb3VwIDgyNzc4IiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg0NjU1IDkxKSIgY2xpcC1wYXRoPSJ1cmwoI2NsaXAtcGF0aCkiPg0KICAgICAgPHBhdGggaWQ9IlBhdGhfODkwNjQiIGRhdGEtbmFtZT0iUGF0aCA4OTA2NCIgZD0iTTUzLjQsODguMzE1YTIuNjg1LDIuNjg1LDAsMCwxLDUuMjE4LjlDNTguNjEzLDkxLDU2LDkxLjksNTYsOTEuOXYuOSIgZmlsbD0ibm9uZSIgc3Ryb2tlPSIjNmU3MzdhIiBzdHJva2UtbGluZWNhcD0icm91bmQiIHN0cm9rZS1saW5lam9pbj0icm91bmQiIHN0cm9rZS13aWR0aD0iMS44Ii8+DQogICAgICA8cGF0aCBpZD0iUGF0aF84OTA2NSIgZGF0YS1uYW1lPSJQYXRoIDg5MDY1IiBkPSJNNTYsMTAwYTksOSwwLDEsMC05LTlBOSw5LDAsMCwwLDU2LDEwMFoiIGZpbGw9Im5vbmUiIHN0cm9rZT0iIzZlNzM3YSIgc3Ryb2tlLWxpbmVjYXA9InNxdWFyZSIgc3Ryb2tlLW1pdGVybGltaXQ9IjEwIiBzdHJva2Utd2lkdGg9IjIiLz4NCiAgICAgIDxwYXRoIGlkPSJQYXRoXzg5MDY2IiBkYXRhLW5hbWU9IlBhdGggODkwNjYiIGQ9Ik01Niw5N2ExLDEsMCwxLDAtMS0xQTEsMSwwLDAsMCw1Niw5N1oiIGZpbGw9IiM2ZTczN2EiLz4NCiAgICA8L2c+DQogIDwvZz4NCjwvc3ZnPg0K);
}

/* Icon 8: Menu Dots */
.icon-menu-dots {
  background-image: url("data:image/svg+xml,%3csvg%20xmlns='http://www.w3.org/2000/svg'%20xmlns:xlink='http://www.w3.org/1999/xlink'%20width='24'%20height='24'%20viewBox='0%200%2024%2024'%3e%3cdefs%3e%3cclipPath%20id='a'%3e%3crect%20width='24'%20height='24'%20fill='%23fff'/%3e%3c/clipPath%3e%3c/defs%3e%3cg%20clip-path='url(%23a)'%3e%3cpath%20d='M12,21a9,9,0,1,0-9-9A9,9,0,0,0,12,21Z'%20fill='none'%20stroke='%236e737a'%20stroke-linecap='round'%20stroke-linejoin='round'%20stroke-width='2'/%3e%3cpath%20d='M12,12v.01'%20fill='none'%20stroke='%236e737a'%20stroke-linecap='round'%20stroke-linejoin='round'%20stroke-width='2'/%3e%3cpath%20d='M8,12v.01'%20fill='none'%20stroke='%236e737a'%20stroke-linecap='round'%20stroke-linejoin='round'%20stroke-width='2'/%3e%3cpath%20d='M16,12v.01'%20fill='none'%20stroke='%236e737a'%20stroke-linecap='round'%20stroke-linejoin='round'%20stroke-width='2'/%3e%3c/g%3e%3c/svg%3e");
}

/* Icon 8: Lightbulb */
.icon-lightbulb {
  background-image: url(data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGQ9Ik0zIDEwVjIxIiBzdHJva2U9IiNGRkFBMkIiIHN0cm9rZS13aWR0aD0iMiIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+DQo8cGF0aCBkPSJNMyAxMEMzLjA2NjY3IDkuNjY2NjcgMy41NiA5IDUgOSIgc3Ryb2tlPSIjRkZBQTJCIiBzdHJva2Utd2lkdGg9IjIiIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgc3Ryb2tlLWxpbmVqb2luPSJyb3VuZCIvPg0KPHBhdGggZD0iTTIxIDEwQzIwLjkzMzMgOS42NjY2NyAyMC40NCA5IDE5IDkiIHN0cm9rZT0iI0ZGQUEyQiIgc3Ryb2tlLXdpZHRoPSIyIiBzdHJva2UtbGluZWNhcD0icm91bmQiIHN0cm9rZS1saW5lam9pbj0icm91bmQiLz4NCjxwYXRoIGQ9Ik0yMSAxMFYyMSIgc3Ryb2tlPSIjRkZBQTJCIiBzdHJva2Utd2lkdGg9IjIiIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgc3Ryb2tlLWxpbmVqb2luPSJyb3VuZCIvPg0KPHBhdGggZD0iTTMgMjFDNC4zNjgxNyAyMC4yMSA1LjkyMDE3IDE5Ljc5NDIgNy41IDE5Ljc5NDJDOS4wNzk4MyAxOS43OTQyIDEwLjYzMTggMjAuMjEgMTIgMjFDMTMuMzY4MiAyMC4yMSAxNC45MjAyIDE5Ljc5NDIgMTYuNSAxOS43OTQyQzE4LjA3OTggMTkuNzk0MiAxOS42MzE4IDIwLjIxIDIxIDIxIiBzdHJva2U9IiNGRkFBMkIiIHN0cm9rZS13aWR0aD0iMiIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+DQo8cGF0aCBkPSJNOS42IDEyLjA3MTRDOC45MjgzOCAxMS41NzY3IDguNDMyMjcgMTAuODg3IDguMTgxOTUgMTAuMDk5OUM3LjkzMTYzIDkuMzEyOTEgNy45Mzk3OCA4LjQ2ODQ3IDguMjA1MjYgNy42ODYyNUM4LjQ3MDc1IDYuOTA0MDIgOC45ODAxIDYuMjIzNjYgOS42NjExNiA1Ljc0MTU1QzEwLjM0MjIgNS4yNTk0MyAxMS4xNjA1IDUgMTIgNUMxMi44Mzk1IDUgMTMuNjU3OCA1LjI1OTQzIDE0LjMzODggNS43NDE1NUMxNS4wMTk5IDYuMjIzNjYgMTUuNTI5MyA2LjkwNDAyIDE1Ljc5NDcgNy42ODYyNUMxNi4wNjAyIDguNDY4NDcgMTYuMDY4NCA5LjMxMjkxIDE1LjgxODEgMTAuMDk5OUMxNS41Njc3IDEwLjg4NyAxNS4wNzE2IDExLjU3NjcgMTQuNCAxMi4wNzE0QzE0LjA4NzcgMTIuMzc1MSAxMy44NTI1IDEyLjc0NjcgMTMuNzEzNSAxMy4xNTYyQzEzLjU3NDUgMTMuNTY1NyAxMy41MzU2IDE0LjAwMTYgMTMuNiAxNC40Mjg2QzEzLjYgMTQuODQ1MyAxMy40MzE0IDE1LjI0NSAxMy4xMzE0IDE1LjUzOTdDMTIuODMxMyAxNS44MzQ0IDEyLjQyNDMgMTYgMTIgMTZDMTEuNTc1NyAxNiAxMS4xNjg3IDE1LjgzNDQgMTAuODY4NiAxNS41Mzk3QzEwLjU2ODYgMTUuMjQ1IDEwLjQgMTQuODQ1MyAxMC40IDE0LjQyODZDMTAuNDY0NCAxNC4wMDE2IDEwLjQyNTUgMTMuNTY1NyAxMC4yODY1IDEzLjE1NjJDMTAuMTQ3NSAxMi43NDY3IDkuOTEyMzUgMTIuMzc1MSA5LjYgMTIuMDcxNFoiIHN0cm9rZT0iI0ZGQUEyQiIgc3Ryb2tlLXdpZHRoPSIyIiBzdHJva2UtbGluZWNhcD0icm91bmQiIHN0cm9rZS1saW5lam9pbj0icm91bmQiLz4NCjxwYXRoIGQ9Ik0xMC4xNjAyIDEyLjg1NzJIMTMuODQwMiIgc3Ryb2tlPSIjRkZBQTJCIiBzdHJva2Utd2lkdGg9IjEuNSIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+DQo8cGF0aCBkPSJNMTIgMkwxMiAxIiBzdHJva2U9IiNGRkFBMkIiIHN0cm9rZS13aWR0aD0iMiIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+DQo8cGF0aCBkPSJNNyA0TDYuMDQ0OTkgMy43MDM0NCIgc3Ryb2tlPSIjRkZBQTJCIiBzdHJva2Utd2lkdGg9IjIiIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgc3Ryb2tlLWxpbmVqb2luPSJyb3VuZCIvPg0KPHBhdGggZD0iTTE2Ljk5OTggNEwxNy45NTQ4IDMuNzAzNDQiIHN0cm9rZT0iI0ZGQUEyQiIgc3Ryb2tlLXdpZHRoPSIyIiBzdHJva2UtbGluZWNhcD0icm91bmQiIHN0cm9rZS1saW5lam9pbj0icm91bmQiLz4NCjwvc3ZnPg0K);
}

/* Avatar */
.header-avatar {
  width: 32px;
  height: 32px;
  max-width: 32px;
  max-height: 32px;
  border-radius: 50%;
  cursor: pointer;
  display: block;
  overflow: hidden;
  flex-shrink: 0;
}
</style>
