# ASP.NET Core（MVC / Razor View） + React（Vite） + Web API の連携メモ

本稿は、Razor View（MVC）でページを開き、ページ内の特定の DOM（id）にビルド済み React コンポーネントをマウントして、React 側から同一アプリ内の Web API（例: `TodoItemsController`）へ通信する実装・開発手順のまとめです。実際に私が行った構成（.NET 10 / Vite + React）をベースに記載します。

---

## 目的
- サーバーサイドの MVC/Razor で画面を提供しつつ、UI の一部を React コンポーネントで実装する
- React コンポーネントからは同一アプリの Web API を呼んでデータ操作を行う（例: `GET /api/TodoItems`）
- 開発時は Vite の HMR を使い、プロキシや dev サーバーを併用して効率的に開発する

---

## 前提（今回の構成）
- ASP.NET Core (.NET 10) アプリ（Razor / MVC + Web API）
- React (Vite) ソースは `ClientApp` 配下
- Vite の build 出力を `wwwroot/js/react` に置くよう設定（`vite.config.ts` で `outDir` を指定）
- Web API コントローラは `api/TodoItems` を提供（`TodoItemsController`）

---

## 主要ポイント
1. 本番はビルド済みの静的 JS を `wwwroot` から配信するため、React の URL は不要（同一オリジン）。
2. 開発時に Vite dev server（ポート例: `5173`）を使う場合は、CORS または Vite の `server.proxy` を使って API にアクセスする。一般的には `proxy` を使うのが簡単。
3. React は View の特定要素（例: `<div id="todoApp"></div>`）に `createRoot(...).render(<TodoApp />)` でマウントする。
4. React は相対 API パス（例: `/api/TodoItems`）を使えば、本番も開発も同じコードで動くようにできる。

---

## Program.cs（重要な設定例）
主要なミドルウェア:
- `UseStaticFiles()` — `wwwroot` からビルド済みファイルを配信
- `MapControllers()` — API を有効にする
- 開発時に Vite を使うなら CORS 設定や proxy のどちらかを使う

（参考）抜粋:

```csharp
// static files
app.UseStaticFiles();
app.UseRouting();

// CORS（開発時にViteを別オリジンで使う場合）
app.UseCors();
