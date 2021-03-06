const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

const dest = "../MdcBlazor/wwwroot";

module.exports = function (env, { mode }) {
    const production = mode === 'production';
    const out_filename = (production) ? 'mdcBlazor.min' : 'mdcBlazor';
    return {
        entry: {
            app: [
                './src/index.ts',
                './src/index.scss'
            ]
        },
        mode: production ? 'production' : 'development',
        optimization: {
            minimize: production
        },
        output: {
            path: path.resolve(__dirname, dest),
            filename: out_filename + '.js'
        },
        devtool: 'eval',
        resolve: {
            extensions: [".ts", ".js", ".css", ".scss"],
            modules: [
                'src',
                path.resolve(__dirname, './node_modules'),
            ]
        },

        module: {
            rules: [
                {
                    test: /\.ts$/i,
                    use: [{ loader: 'ts-loader', options: { transpileOnly: true } }],
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
        plugins: [
            new MiniCssExtractPlugin({
                filename: out_filename + '.css',
            })
        ],
    };
}