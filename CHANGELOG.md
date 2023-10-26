# Changelog

## [0.4.0] - 2023-10-26

### 重構
- 使用 Scope-Item-Styler 架構進行重構，使設計邏輯更清晰

## [0.3.0] - 2023-10-24

### 新增
- `ClassStyler` : 使用 `USS` 定義樣式並通過 `ClassStyler` 為 `Decorator` 指定
- `InspectorMaidSetting` : 用來存放與 `Inspector Maid` 相關的偏好設定

## [0.2.0] - 2023-10-24

### 新增
- `Styler` 系統 : 調整各 `Decorator` 的 `IStyle` 屬性。
- `ContainerDrawer` : 建立一個空的裝飾器
- `HelpBoxDrawer` : 產生提示訊息框
- `ButtonDrawer` : 產生可互動按鈕

### 修正
- 私有欄位無法繪製錯誤

### 重構
- 底層部分重構使其可以與 `StylerAttribute` 進行互動


## [0.1.0] - 2023-10-21

### 新增
- 首次發布專案。
- 基本框架已經穩定，可供開發使用。