import React from 'react';
import ReactDOM from 'react-dom/client';
interface ProductProps {
    id: number;
    name: string;
    price: number;
}const ProductDetail: React.FC<ProductProps> = ({ id, name, price }) => {
    return (
        <div>
            <h3>{name}</h3>
            <p>ID: {id}</p>
            <p>価格: {price.toFixed(2)}円</p>
            <button onClick={() => alert(`${name} を購入しました!`)}>購入</button>
        </div>
    );
};

const rootElement = document.getElementById('product-detail-root');

if (rootElement) {
    //data-product属性からJSON文字列を取得
    const productJson = rootElement.dataset.product;

    if (productJson) {
        try {
            //JSON文字列をパースしてオブジェクトに変換
            const raw = JSON.parse(productJson);

            const productProps: ProductProps = {
                id: Number(raw.Id),
                name: String(raw.Name),
                price: Number(raw.Price),
            }

            console.log("parsed =", productProps, "typeof price =", typeof productProps.price);
            const root = ReactDOM.createRoot(rootElement);
            root.render(
                <React.StrictMode>
                    <ProductDetail {...productProps} />
                </React.StrictMode>
            );

        } catch (error) {
            console.error('error', error);
        }
    } else {
        console.warn('data-product attribute not found on #product-detail-root');
    }

}