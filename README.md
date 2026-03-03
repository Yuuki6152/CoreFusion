<<<<<<< HEAD
# CoreFusion
=======
CoreFusion
>>>>>>> cec6f887de3eee0cb66a6789534740b156339b7c

ASP.NET Core MVC + React（Vite）統合スターターテンプレート

CoreFusion は、ASP.NET Core MVC をバックエンドに、React（Vite）をフロントエンドとして統合するための実践的なテンプレートです。

業務アプリ・企業向けWebアプリ・段階的SPA移行を想定した構成になっています。

<<<<<<< HEAD
---

## 🚀 特徴

* ASP.NET Core MVC バックエンド
* React + Vite フロントエンド
* Reactビルド成果物を `wwwroot` に出力
* MVCレイアウトを維持したままReactを統合
* SEOに強い構成（完全SPAではない）
* TypeScript対応
* 実務向けディレクトリ構成

---

## 📁 プロジェクト構成

```
=======
⸻

🚀 特徴
	•	ASP.NET Core MVC バックエンド
	•	React + Vite フロントエンド
	•	Reactビルド成果物を wwwroot に出力
	•	MVCレイアウトを維持したままReactを統合
	•	SEOに強い構成（完全SPAではない）
	•	TypeScript対応
	•	実務向けディレクトリ構成

⸻

📁 プロジェクト構成

>>>>>>> cec6f887de3eee0cb66a6789534740b156339b7c
CoreFusion/
│
├── Controllers/
├── Models/
├── Views/
│   └── Shared/
│
├── wwwroot/
│   └── js/react/        ← Reactビルド成果物
│
├── ClientApp/           ← React (Vite) アプリ
│   ├── src/
│   ├── public/
│   ├── vite.config.ts
│   └── package.json
│
└── Program.cs
<<<<<<< HEAD
```

---

## 🛠 セットアップ方法

### ① リポジトリをクローン

```bash
git clone https://github.com/YOUR_ID/CoreFusion.git
cd CoreFusion
```

---

### ② バックエンド起動（ASP.NET Core）

```bash
dotnet restore
dotnet run
```

---

### ③ フロントエンド起動（開発モード）

```bash
cd ClientApp
npm install
npm run dev
```

---

### ④ 本番ビルド（重要）

Reactをビルドし、ASP.NETの `wwwroot` に出力します。

```bash
cd ClientApp
npm run build
```

出力先：

```
wwwroot/js/react/
```

---

## ⚙ Vite設定概要

* 出力先：`wwwroot/js/react`
* baseパス：`/js/react/`
* エントリーポイント：`main.js`

---

## 🔌 MVCとの統合方法

`_Layout.cshtml` に以下を追加します。

```html
<script type="module" src="~/js/react/main.js"></script>
```

これにより：

* MVCのレイアウトは維持
* Reactは指定領域のみ制御
* CSS衝突を防止

---

## 🎯 想定ユースケース

* 業務系Webアプリ
* 企業向け管理画面
* 段階的SPA移行プロジェクト
* MVCからReactへの移行基盤
* SEOを考慮したハイブリッド構成

---

## 🔮 今後の拡張予定

* JWT認証テンプレート追加
* APIサンプル実装
* Docker対応
* GitHub ActionsによるCI構築
* React Router導入例

---

## 📜 ライセンス

MIT License
=======


⸻

🛠 セットアップ方法

① リポジトリをクローン

git clone https://github.com/YOUR_ID/CoreFusion.git
cd CoreFusion


⸻

② バックエンド起動（ASP.NET Core）

dotnet restore
dotnet run


⸻

③ フロントエンド起動（開発モード）

cd ClientApp
npm install
npm run dev


⸻

④ 本番ビルド（重要）

Reactをビルドし、ASP.NETの wwwroot に出力します。

cd ClientApp
npm run build

出力先：

wwwroot/js/react/


⸻

⚙ Vite設定概要
	•	出力先：wwwroot/js/react
	•	baseパス：/js/react/
	•	エントリーポイント：main.js

⸻

🔌 MVCとの統合方法

_Layout.cshtml に以下を追加します。

<script type="module" src="~/js/react/main.js"></script>

これにより：
	•	MVCのレイアウトは維持
	•	Reactは指定領域のみ制御
	•	CSS衝突を防止

⸻

🎯 想定ユースケース
	•	業務系Webアプリ
	•	企業向け管理画面
	•	段階的SPA移行プロジェクト
	•	MVCからReactへの移行基盤
	•	SEOを考慮したハイブリッド構成

⸻

🔮 今後の拡張予定
	•	JWT認証テンプレート追加
	•	APIサンプル実装
	•	Docker対応
	•	GitHub ActionsによるCI構築
	•	React Router導入例

⸻

📜 ライセンス

MIT License
>>>>>>> cec6f887de3eee0cb66a6789534740b156339b7c
