import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import path from 'path';
// https://vitejs.dev/config/
export default defineConfig({
    plugins: [react()],
    root: 'src', // ソースコードのルートをsrcに設定
    //ビルド成果物の参照先の基準URL
    base: '/js/react/',

    build: {
        outDir: path.resolve(__dirname, '../wwwroot/js/react'), // ビルド結果をMVCのwwwroot/js/reactに出力
        emptyOutDir: true, // 出力ディレクトリをクリーンアップ
        rollupOptions: {
            input: {
                main: path.resolve(__dirname, 'src/main.tsx'), // エントリーポイント
                //別のReactアプリやコンポーネントがある場合、ここに追加できる
                //otherApp: path.resolve(__dirname, 'src/OtherApp/main.tsx'),
                product: path.resolve(__dirname, 'src/product-detail.tsx'),
                profile: path.resolve(__dirname,'src/user-profile.tsx'),
            },
            output: {
                entryFileNames: '[name].js', // エントリーポイントのファイル名を main.js とする
                chunkFileNames: 'chunks/[name]-[hash].js', // 分割されたチャンクのファイル名
                assetFileNames: 'assets/[name]-[hash][extname]', // 静的アセットのファイル名
            }
        }
    }
});