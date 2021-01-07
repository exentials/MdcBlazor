const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

const dest = "../MdcBlazor/wwwroot";

module.exports = function (env, { mode }) {
    const production = mode === 'production';
    return {
        entry: {
            app: [
                './src/index.ts',
                './src/index.scss'
            ]
        },
        mode: production ? 'production' : 'development',
        output: {
            path: path.resolve(__dirname, dest),
            filename: 'mdcBlazor.js'
        },

        resolve: {
            extensions: [".ts", ".js", ".css", ".scss"],
            modules: [
                'src',
                //'node_modules',
                path.resolve(__dirname, './node_modules'),
            ]
        },

        module: {
            rules: [
                {
                    test: /\.ts$/i,
                    use: "ts-loader",
                    exclude: /node_modules/
                },
                {
                    test: /\.s[ac]ss$/i,
                    use: [
                        MiniCssExtractPlugin.loader,
                        "css-loader",
                        {
                            loader: "sass-loader",
                            options: {
                                sassOptions: {
                                    "includePaths": [
                                        path.resolve(__dirname, './node_modules')
                                    ]
                                }
                            }
                        }
                    ],
                },
            ],
        },
        plugins: [new MiniCssExtractPlugin({
            filename: 'mdcBlazor.css',
        })],
    };
}