# Changelog

## [2.1.0] - 2023-11-10

### 新增

- `Widget` 現在可以透過在 `Class` 上定義 `WidgetAttribute` 的方式深度自定義布局方式。
- `StyleStringConverter` : 用於將 `StyleString` 格式的 `string` 轉換為 `StyleValue` 的工具函式。

### 更新

- Sample Script 基於 Class Attribute 重寫，減少對 Sample 欄位的干擾並美化介面。
### 修正

- 修正 Slot 參數名稱錯誤

### 重構
- `Context` 連結方式改為由父 `Context` 主動 `Attach()` 子 `Context`。
- 廢棄 `ContainerScope` 改為使用 `ColumnScope` 及 `RowScope`，這能讓語意更明確。
- 將初始化模板邏輯轉移到 `MemberWidgetTemplates` ，使 `ClassWidget` 職責單一化。

## [2.0.0] - 2023-11-09

### 新增

- `IChangedNotifierService` : 用以註冊監聽成員資料、並在資料變更時發出通知。

### 更動

- 調整 `ReadOnly`、`Hide`、`Label` 運作邏輯，現在他們被歸類為一種 `Styler`，不再只服務於 `Target`。

### 重構

- 使用 `Widget`-`Context`-`VisualElement` 架構重寫、使職責更明確。

## [1.3.1] - 2023-11-05

### 修正

- `GetBindingValue` 判斷目標錯誤問題。

## [1.3.0] - 2023-11-05

### 新增

- `FastReflectionService` : 利用快速反射存取指定欄位。

### 重構

- 使用 `FastReflectionService` 重構與資料綁定相關的功能，以提升存取效能。

## [1.2.2] - 2023-11-03

### 修正

- package 版本序列錯誤。

## [1.2.1] - 2023-11-03

### 修正

- Property And Method 示範場景 `GameObject` 名稱未命名錯誤。

## [1.2.0] - 2023-11-03

### 新增

- 內置小部件 `Foldout` 新增 expand 屬性，以設定預設是否展開。
- 新增缺少的 `WidgetAttribute` 示範，並美化畫面。
- 新增 Property And Method 示範場景，展示如何顯示屬性、欄位。

### 修正

- `Label` 無法正常運作錯誤。
- `MethodElement` 預設為展開錯誤。

### 重構

- 剝離 `WidgetTree` 自我複製的功能到 `WidgetTreeDrawer` 以符合單一職責原則。

### 雜項

- 發佈分支更名為 upm，並免與 relesae/v 分支衝突。
- Sample 新增單元前綴以使其單元化。

## [1.1.0] - 2023-11-03

### 新增

- 特殊屬性 `TemplateAttribute` : 設定 `WidgetTree` 模板屬性，以修改模板名稱或是否在 inspector 中顯示。
- 內置小部件 `CardScope` : 帶有輕微圓角和立面陰影的面板。
- 內置小部件 `Slot` : 插入指定模板使不同欄位可以結合在一起。

### 重構

- 重新命名大量類別以及重組架構，以增加可讀性與可擴展性。
- 現在每個 `WidgetTree` 都可以是被視為一個模板，以供 `Slot` 使用。

## [1.0.2] - 2023-10-30

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