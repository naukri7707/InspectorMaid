# Changelog

## [1.0.1] - 2023-10-30

### 修正
- package 版本序列錯誤

## [1.0.1] - 2023-10-30

### 重構
- 使 MethodElement 函式被調用時觸發 Repaint 事件

## [1.0.0] - 2023-10-27

### 新增
- `MethodElement` 現在支援帶參數的函式了，當傳入的參數可以被 `PropetyBuilder` 建立，`MethodElement` 便會在 Foldout content 中產生對應的欄位用以設定參數。
- `PropetyBuilder` 現在如果目標類別沒有被註冊，會在已註冊的類別中尋找與目標最接近的類別進行實作。這可以幫助產生類似 GameObject、Collider 等欄位。
- `FoldoutDrawer` : 建立一個可以動態改變是否顯示的區域。
- `DividerDrawer` : 產生一個分隔線，用以分割不同區域的 UI。

### 修正
- `PropetyBuilder` 無法正確存取 Enum 型態的欄位錯誤。
- 修正部分類別命名空間錯誤問題。

### 刪除
- 移除 `ShowDrawer` 因為其功能可以完全被 `ShowDrawer` 覆蓋。

### 重構
- 使用 getter + setter 重構 `PropetyBuilder` 使其與 PropertyInfo 屬性解耦。
- 移除不再需要的 `CustomDrawerWithDecoratorOf` 類別，現在 `CustomDrawerOf` 直接繼承自 `CustomDrawer`。

## [0.5.0] - 2023-10-27

### 更新
- 美化 Sample 腳本並加入簡單的講解，使其更具參考性。

### 重構
- 使用超集合 Style 取代所有的 Styler，降低認知負荷並使程式碼更簡潔。

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