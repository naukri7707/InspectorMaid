# 功能入門

## 透過 `WidgetAttribute` 描述 `WidgetTree` 來繪製 UI

Inspector Maid 繪製的 UI 主要透過利用由以下 3 種 `WidgetAttribute` 描述對應的功能，並互相協作組合而成。

1. `Item` : 沒有子元素的小部件，例如 `Button`、`HelpBox` 或是欄位本身 `Target`。
2. `Scope` : 可以容納有子元素的小部件，例如 `Container` 和 `Foldout`。
3. `Styler` : 用於設計小部件風格，例如 `Style` 、 `ReadOnly` 及 `Label`。
4. `Logic` : 用於標註特殊行為，例如 `EndScope` 及 `Template`。

Inspector Maid 會為每一個目標建立一棵 `WidgetTree`，並根據不同的 `WidgetAttribute` 產生對應的 `Widget` 進行組合。最終組成類似於下圖的結構：

![structure-1](./Images/structure-1.png)

這看起來有點抽象，讓我們來點具體的例子，讓你簡單理解如何使用 Item、Scope 以及 Styler 互相協作以產生想要的 UI 。

假如我希望為我的 `int` 欄位建立一個具有以下特色的 UI

1. 如果 `int` 不為 0 ，在目標欄位之下產生一個按鈕，用來將 `int` 重置為 0
2. 顯示一些幫助資訊用來介紹功能
3. 強調幫助資訊，讓它更醒目一點

![intro-step-5](./Images/intro-step-5.png)

讓我們一步一步來完成他:

<details>
<summary>1. 建立一個按鈕用來重置 Int 的值</summary>

![intro-step-1](./Images/intro-step-1.png)

首先我們先在 `myInt` 上加入一個 `ButtonAttribute` 以產生一個按鈕。

而為了能讓按鈕重置 `myInt`，我們還需要綁定一個函式，讓按鈕在按下後調用該函式將 `myInt` 歸零。

```cs
[Button("Reset", binding: nameof(ResetValue))]
public int myInt;

public void ResetValue()
{
    myInt = 0;
}
```

</details>

<details>
<summary>2. 將按鈕放到目標欄位之下</summary>

![intro-step-2](./Images/intro-step-2.png)

一般情況下目標欄位會在所有的 `Widget` 繪製完畢後進行繪製，如果想要提前進行繪製，我們需要使用 `TargetAttribute` 來標註它應該在哪裡繪製。

```cs
[Target]
[Button("Reset", binding: nameof(ResetValue))]
public int myInt;

public void ResetValue()
{
    myInt = 0;
}
```

</details>

<details>
<summary>3. 讓按鈕在 myInt 為 0 時隱藏</summary>

![intro-step-3.1](./Images/intro-step-3.1.png)
![intro-step-3.2](./Images/intro-step-3.2.png)

為了在 `myInt` 為 0 時隱藏按鈕，我們需要使用 `HideIfScopeAttribute` 它會偵測綁定的 `bool` 如果為 `true`，便隱藏全部隸屬於他的 `Widget`。

```cs
[Target]
[HideIfScope(binding: nameof(IsMyIntZero))]
[Button("Reset", binding: nameof(ResetValue))]
public int myInt;

private bool IsMyIntZero => myInt == 0;

public void ResetValue()
{
    myInt = 0;
}
```

</details>

<details>
<summary>4. 加入一些幫助資訊</summary>

![intro-step-4](./Images/intro-step-4.png)

我們可以使用 `HelpBox` 來顯示想呈現的幫助資訊。

```cs
[HelpBox("The button will show If the value is not zero.", HelpBoxMessageType.Info)]
[HelpBox("You can press the button to reset value.", HelpBoxMessageType.Info)]
[Target]
[HideIfScope(binding: nameof(IsMyIntZero))]
[Button("Reset", binding: nameof(ResetValue))]
public int myInt;

private bool IsMyIntZero => myInt == 0;

public void ResetValue()
{
    myInt = 0;
}
```

</details>

<details>
<summary>5. 強調幫助訊息</summary>

![intro-step-5](./Images/intro-step-5.png)

為了強調幫助訊息我們可以使用 `ContainerScope` (一個空的 Scope) 來將它們包裝起來。並利用 `Style` 來調整它的風格。

由於我們只要強調提示訊息的部分，所以我們在 `Target` 之前使用 `EndScope` 將 Scope 關閉，這樣才不會強調到不相干的 `Widget`。

你可能有發現 `HideIfScope` 並沒有使用 `EndScope` 關閉，這是因為未閉合 Scope 會在所有 `Widget` 被繪製完畢後自動關閉，所以我們可以將其省略掉。

```cs
[ContainerScope, Style(borderRadius: "5", padding: "3", marginVertical: "5", backgroundColor: "#AAAA2040")]
[HelpBox("The button will show If the value is not zero.", HelpBoxMessageType.Info)]
[HelpBox("You can press the button to reset value.", HelpBoxMessageType.Info)]
[EndScope]
[Target]
[HideIfScope(binding: nameof(IsMyIntZero))]
[Button("Reset", binding: nameof(ResetValue))]
public int myInt;

private bool IsMyIntZero => myInt == 0;

public void ResetValue()
{
    myInt = 0;
}
```

</details>

## 如何使用 `Style` 定義 `Widget` 的風格

### 設定風格的屬性

任何型態的屬性都使用 `string` 來進行設定，Inspector Maid 會自動將其轉換成目標數值，如果要調整屬性，請依該屬性的型態作出如下調整：

- `StyleInt` : 使用整數字串 e.g. `"0"`, `"10"`
- `StyleFloat` : 使用浮點字串 e.g. `"0.5"`, `"11.7"`
- `StyleLength` : 使用浮點字串，如果要指定單位則在後面將上對應的符號 e.g. `"13px"`, `"40%"`，如果沒有填入單位的話會使用預設的單位來計算 (px)。
- `StyleColor` : 使用 HexColor 或 RBGA 色彩來設定 e.g. `"#FF0000FF"`, `"0,255,0,255"`，其中 alpha 值是可選項，如果沒有填入則預設為不透明 (FF / 255) e.g. `"#FF0000"`, `"0,255,0"`
- `StyleEnum` : 使用對應 `Enum` 的名稱 e.g. `"row"`, `"column"` ， 也可以使用 nameof 運算式輔助 e.g. `nameof(FlexDirection.Row)`, `nameof(FlexDirection.Column)`。

對於部分高度相關的屬性 (如：`margin`、`padding` 等系列屬性) 我們可以使用速記屬性 (Shorthand Property) 來簡化設定流程。

```cs
[ContainerScope, Style(padding: "10", backgroundColor: "#FF0000")] // all
[ContainerScope, Style(padding: "10 20", backgroundColor: "#00FF00")] // vertical horizontal
[ContainerScope, Style(padding: "10 20 30", backgroundColor: "#0000FF")] // top horizontal bottom
[ContainerScope, Style(padding: "10 20 30 40", backgroundColor: "#AAAA00")] // top right bottom left
[Target, Style(backgroundColor: "#000000")]
public int shorthandProperty = 0;
```

如果不想修改該屬性，可以將對應的參數設為 `null` 來表示不修改。 `null` 這也是參數的預設值，畢竟在設計上不可能每個屬性都要修改。因此在絕大部分情況下你不會使用到 `null`。

### 使用具名指定要指派的參數

在 `Style` 的建構子中有數十個參數可以指派，依序填入 `null` 直到目標欄位顯然是不明智的；我們可以使用具名參數來直接對該參數進行設定，也可以讓程式碼更具可讀性。

```cs
[Target, Style(null, null, null, null, null, "30")] // Don't do this
public int bad;

[Target, Style(marginTop: "30", paddingLeft: "5")] // Do this
public int good;
```

### 使用 classList 屬性引用在 uss 中預定義的風格

在網頁設計中我們會在 `css` 中定義常用的風格，並在 `HTML` 中引用；在 Inspector Maid 中我們也可以達成類似的效果。

1. 首先我們需要建立一個 `uss` 檔案，你可以透過在 Project 視窗中右鍵選擇 `Create/UI Toolkit/Style Sheet` 來建立。

2. 接著我們要定義風格。 `uss` 的定義方式與 `css` 基本一致，如果有相關經驗的話應該能輕鬆上手。

    ```css
    .width-50-percent {
        width: 50%;
    }

    .height-50-px {
        height: 50px;
    }
    ```

3. 再來我們需要讓 Inspector Maid 知道有哪些 `uss` 可以參考。你可以在 Project Settings 視窗中的 Inspector Maid 分頁中找到 `Import Style Sheets` 欄位，並將目標 `uss` 拖曳至該欄位中以新增參考。

4. 最後我們找到想要引用預定義風格的欄位，並使用 `Style` 中的 `classList` 參數新增目標 class 名稱即可。注意：如果有多個 class 要引用需使用空格進行分隔。

    ```cs
    [Target, Style(classList: "width-50-percent height-50-px")]
    public int styleTest;
    ```

5. 你也可以將 `classList` 與其他屬性混合使用，不過要注意 `classList` 的優先度是最低的，類似於 `HTML` 中 `class` 與 `inline-style` 的關係。

    ```cs
    [Target, Style(classList: "width-50-percent height-50-px", justifyContent: nameof(Align.Center))]
    public int styleTest;
    ```

### 屬性在衝突時的優先級

`Style` 中的部分屬性可能會對同一目標進行重複設定：以 `marginTop` 為例：`marginTop`、`marginVertical`、`marginAll`、`margin` 以及 `classList` 都可能影響到它。

在這時候遵循「選擇越少、目標越單一，優先度越高」的原則進行處理。因此在這種情況下的各屬性的優先級為：
> `marginTop` > `marginVertical` > `marginAll` > `margin` > `classList`

## 在序列化類別、結構上繪製 UI

- 在序列化類別、結構上繪製 UI 的邏輯與在一般腳本上無異。但由於 Unity 的限制，如果想要使用 Inspector Maid 的話，你需要實作空介面 `IInspectorMaidTarget` 才可以正常運作。

    ```cs
    [Serializable]
    public class MyClass : IInspectorMaidTarget
    {
        public int myInt;

        [ReadOnly]
        public int myString;

        [Target]
        public void Hello(string message = "World")
        {
            Debug.Log($"Hello, {message}!");
        }
    }
    ```

## 在 Inspector 上繪製屬性及函式

![draw-property-and-method](./Images/draw-property-and-method.png)

經常使用 Unity 的人應該都知道：屬性及函式是無法被繪製到 Inspector 上。這並不難理解，因為 Inspector 本質上就是用來設定序列化資料用的工具視窗。但在實務上我們總有想要監看屬性的當前資料、或是調用特定函式的時候。雖然我們可以利用 `Debug.Log()`、註冊快捷鍵或是使用中斷點等方式達成目的。但這顯然很笨重，也不視覺化。因此我們選擇利用反射來讓屬性及函式可以被呈現在 Inspector 之上，方便監看即調用。

### 如何使用

要顯示屬性或函式其實非常簡單，只需要在其之上使用任意一個 `WidgetAttribute` 即可，實際上你也可以使用它來設計屬性及函式的 UI，就像是欄位一樣。

不過大部分時候你可能只希望顯示該目標而不做任何設計，這時候 `TargetAttribute` 會是你最好的選擇。

```cs
public int myField;

[Target]
private int MyProperty => myField;

[Target]
public void MyMethod()
{
    Debug.Log("Hello, world!");
}
```

### 關於屬性

- 如果你的屬性是只有 getter (read-only)，繪製出的欄位將會被禁用 (無法更改)。
- 如果你的屬性是只有 setter (write-only)，繪製出的欄位將不會追蹤目標的當前值，但當欄位發生改變時會將值賦予到目標上 (這有點危險，謹慎使用)。
- 目前還無法繪製 Array、List 及 Object (不是 UnityEngine.Object)

### 關於函式

- 帶有參數的函式可以透過展開 Foldout 後對顯示的欄位進行調整

    ![about-method-1](./Images/about-method-1.png)

    ```cs
    [Target]
    public void MyMethod(int myInt)
    {
        Debug.Log($"Yout int: {myInt}");
    }
    ```

- 如果參數有預設值，它也會是對應欄位預設值

    ![about-method-1](./Images/about-method-2.png)

    ```cs
    [Target]
    public void MyMethod(int withoutDefault, int withDefault = 10)
    {
    }
    ```

## 綁定 (繫結)

部分 `WidgetAttribute` 可以與指定特定欄位讓對應的 `Widget` 與其進行資料綁定，用以完成一些特殊功能。綁定的目標可以是該腳本的物件本身或是該物件下的任何成員。

- 如果要綁定成員，將 `binding` 指派為該成員的名稱以進行綁定。你可以使用 `nameof` 運算式來使程式碼更容易維護。

    ```cs
    [HelpBox(binding: "message")] // Bad
    [HelpBox(binding: nameof(message))] // Good!
    public string message = "Hello World!";
    ```

- 依據綁定的成員類型不同，會有不同的回傳邏輯

    1. 欄位：該欄位的數值。
    2. 屬性：該屬性 `getMethod` 的回傳值，如果該屬性沒有 `getMethod` 則無法運行。
    3. 函式：該函式調用後的回傳值，如果該函式有參數則需使用 `args` 定義參數。

        ```cs
        // 如果目標是帶參數函式，使用 new object[] { ... } 來包裹參數
        [HelpBox(binding: nameof(HelloTwoMessage), args: new object[] { "Hello", "world" })]
        public string message = "";
        
        public string CombineMessage(string message1, string message2)
        {
            return $"{message1} {message2}!";
        }
        ```

### 注意事項

- 與傳統的 MVVM 模式使用觀察者模式實作綁定不同，Inspector Maid 會在每次 EditorUpdate 時主動獲取已綁定成員的當前值，然後將其與舊值進行比較，並在需要時發出通知以處理變更。

- 儘管這種特殊的實作方式在處理資料更新方面可能會消耗一些效能，但由於資料存取部分使用快速反射進行優化，實際的效能損耗不會太高。考慮到本工具僅在 Unity Editor 上運行，並且無需額外的程式碼即可實現資料綁定，我們認為這個犧牲是完全可以接受的。

## 自訂小部件

沒有完美的工具，Inspector Maid 雖然提供了許多泛用的内置小部件，但較複雜的設計可能需要大量使用的 `WidgetAttribute` 進行描述才能完成設計，或是内置小部件根本沒有相關的功能。這時後你可以透過自訂小部件，將複雜的 UI 設計定義於一個 `Widget` 中在來提升程式碼的可讀性。以及透過自訂小部件來實作想要的功能。

### 建立 `WidgetAttribute`

`WidgetAttribute` 用來將一些資訊從腳本傳遞給 `Widget`，

1. 首先我們需要建立用來定義 `Widget` 位置及屬性的 `WidgetAttribute`。要注意根據目標功能不同，你需要繼承的類別也有所不同。

    ```cs
    // Item : 單一個小部件
    public class MyItemAttribute : ItemAttribute { }
    // Scope : 可以包裝其他小部件的小部件 (需使用 EndScope 關閉)
    public class MyScopeAttribute : ScopeAttribute { }
    // Styler : 定義前一個小部件的風格
    public class MyStylerAttribute : StylerAttribute { }
    ```

2. 你可能會想要傳入一些參數給 `WidgetAttribute`，我們推薦使用 `readonly field` 以保證其不可變性。

    ```cs
    public class MyItemAttribute : ItemAttribute
    {
        public MyItemAttribute(string myString)
        {
            this.myString = myString;
        }

        public readonly string myString;
    }
    ```

3. 有些參數可能是選擇性的，我們建議使用預設引數來定義預設值，因為它能夠被 IDE 偵測到並顯示。

    ```cs
    public class MyItemAttribute : ItemAttribute
    {
        public MyItemAttribute(string myBadOptionalString = null, string myOptionalString = "default value")
        {
            if(myBadOptionalString != null)
            {
                this.myBadOptionalString = myBadOptionalString;
            }   
            this.myOptionalString = myOptionalString;
        }
        public readonly string myBadOptionalString = "default value";

        public readonly string myOptionalString;
    }
    ```

    ![optional-variable-compare](Images/optional-variable-compare.png)

### 建立 `Widget`

根據 `WidgetAttribute` 的不同，我們需要繼承的類別也有所不同

- `ItemAttribute` : `ItemWidgetOf<T>`
- `ScopeAttribute` : `ScopeWidgetOf<T>`
- `StylerAttribute` : `StylerWidgetOf<T>`

> 由於 Widget 在實作中可能會使用到 UnityEditor 中的函式。所以建議新增在 Editor 資料夾中，使 unity 不在建置時編譯該腳本。否則專案將無法建置。

#### `VisualWidget` : 實作 `Build()`

當你的目標是 `ItemWidget` 或是 `ScopeWidget` 時，你需要實作 `Build()` 函式來描述 `Widget` 的 UI。

```cs
public class MyScopeWidget : ScopeWidgetOf<MyScopeAttribute>
{
    public override VisualElement Build(IBuildContext context)
    {
        // 建立一個容器來存放要產生的 UI
        var container = new VisualElement();

        // 假設我們想要一個 Label
        var label = new Label("Hello World!");
        container.Add(label);

        // 如果是 Scope，我們還需要使用 BuildChildren 
        // 來建立子 Widget 並將其加入到 container 之中
        BuildChildren(context, (ctx, e) =>
        {
            // ctx 是子 Widget 的 Context
            // e 是子 Widget 在 Build() 之後產生的 VisualElement
            // 我們將產生的 VisualElement 簡單的加入到 container 之中
            container.Add(e);
        });

        return container;
    }
}
```

#### `StylerWidget` : 實作 `OnStyling()`

當你的目標是 `StylerWidget` 時，你需要實作 `OnStyling()` 函式來描述如何調整目標 `VisualElement` 的風格。

```cs
public class MyStylerWidget : StylerWidgetOf<MyStylerAttribute>
{
    // OnStyling 會在 stylingElement 被 Build() 後呼叫
    // stylingElement 會是該 Styler 之前最接近的 VisualWidget 所產生的 VisualElement
    public override void OnStyling(IBuildContext context, VisualElement stylingElement)
    {
        // 這裡可以對 stylingElement 做任何事情，例如將其禁用
        stylingElement.SetEnabled(false);

        // 或是設定他的 style
        stylingElement.style.backgroundColor = Color.red;
    }
}
```

### `IBuildContext`

- 你可以使用 `Context` 來訪問上下文的資源，例如：`Context`、`Widget`、`WidgetAttribute` 或是 `Service`。
- 為了提高程式碼的簡潔性，接口中使用 `IBuilderContext` 來間接操作 `Context`。實際上，`IBuilderContext` 僅由 `Context` (及其衍生類別) 實作。因此如果你需要使用到 `Context` 的特性，你可以將 `IBuilderContext` 轉型為 `Context`來使用，這是絕對安全的。

### `Service`

通用功能將以服務的形式提供。您可以使用 `GetService()` 方法來獲取相應的服務。不過這些服務所提供的功能多會以擴展方法的方式整合到 `IBuildContext` 中。因此在大多數情況下您無需直接訪問服務，僅需透過擴展方法來調用這些功能即可。

#### 內置 `Service`

- `IEditorEventService`：取得 Editor 事件的回調 e.g. `OnUpdate`、`OnSceneGUI`、`OnDestroy`。
- `IInspectorMaidSettings`：取得 Inspector Maid 在 Project Setting 中的設定資料。
- `IFastReflectionService`：使用快速反射存來取目標成員。
- `IChangedNotifierService`：監聽目標成員，在該成員產生變更時發送通知。

### `Receiver`

你可以在 `Widget` 上實作目標 `Receiver` 來接收系統事件，這能幫助你在除了 Build 之外的特定階段建立邏輯。

#### 內置 `Receiver`

- `IContextAttachedReceiver`：當該 `Widget` 的 `Context` 被附加到 `Context Tree` 時。

### 資料綁定

如果想要支援資料綁定，你可以在 `WidgetAttribute` 上實作 `IBindable` 介面使 `Widget` 可以使用包裝好的綁定函式，或者你也可以在 `Widget` 上直接使用 `GetValue()` 等函式來存取目標成員。

`MyItemAttribute.cs`

```cs
public class MyItemAttribute : ItemAttribute, IBindable
{
    public MyItemAttribute(
        string myString,
        string binding = null,
        params object[] args
        )
    {
        this.myString = myString;
        this.binding = binding;
        this.args = args;
    }

    public readonly string myString;

    public string binding { get; }

    public object[] args { get; }
}
```

`MyItemWidget.cs`

```cs
    public class MyItemWidget : ItemWidgetOf<MyItemAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            // 獲取綁定成員的值
            var bindingValue = context.GetBindingValue();
            // 監聽綁定成員的值
            context.ListenBindingValue(value =>
            {
               // Do something on value changed
            });
            
            // 你也可以直接指定成員名稱來存取
            var a = context.GetValue("memberName");
            context.ListenValue("memberName" ,value =>
            {
                // Do something
            });
        }
    }
```

## 内置小部件

你可以在 package 中的 Sample 中找到所有内置小部件的 demo 以及詳細的說明。
