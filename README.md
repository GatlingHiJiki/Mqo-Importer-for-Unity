Mqo-Importer-for-Unity
======================
Metasequoia　モデルデータ・フォーマット（.mqo）の読み込みを目的としたインポーター.

現在、ガトリングひじき個人によって運営され、開発が行われています.

##使用するには

プロジェクト追加後、メニューバーにImporterタブが出現.<br\/>
そのタブのMQO Loaderを選んでください.
ウィンドウが表示されます.<br\/>
そのウィンドウの空欄に、．mqoファイルをD&Dし、
Convertボタンをクリックすることでprefab化されます.<br\/>

ウィンドウサンプル画像：<br\/>
![sample](https://raw.github.com/YuhaOh/Mqo-Importer-for-Unity/master/Window_sample.jpg)
<br\/>

##開発ログ
12/19/2012:<br\/>
Constantシェーダ追加.<br\/>
バグ：
　マテリアルの無い状態でインポートできない.<br\/>
　Constantシェーダ以外のシェーダは未実装、Diffuseシェーダを割り当てている.<br\/>


12/17/2012:<br\/>
実際に作ったものをUp.　作りが粗いので、今後改修を行なっていく形になります.<br\/>
今は各種Metasequoiaシェーダに対応したシェーダを作成中です.<br\/>

##ライセンス
改変・再配布は自由です.<br\/>
利用した場合の報告は必要ありません.<br\/>
修正BSDライセンスに準拠としています.<br\/>

##免責
Mqo-Importer-for-Unityはゲーム制作及びMetasequoiaでのモデル制作を支援するために開発されたスクリプトですが、
利用者の利用方法において被った損害についてガトリングひじきはその責任を負いません.<br>
Mqo-Importer-for-Unityは利用者ご自身の判断と責任において利用していただくものとします.<br>
また、利用者がモデル及びシェーダなどの利用方法において被った損害についても同様と致します.<br>

##感謝
このソースは、UnityでMMDを動かす会の、MMD-for-Unityを参考に作らせていただきました.<br\/>
http://sourceforge.jp/projects/mmd-for-unity/<br\/>

(C)桒野真行
