import webpack from "webpack";

import webpackMerge from "webpack-merge";
import common from "./webpack.config.common";

const config: webpack.Configuration = webpackMerge(common, {
  mode: "development",
  devtool: "inline-source-map",
  devServer: {
    contentBase: "./dist",
    hot: true,
    historyApiFallback: true,
  },
  module: {
    rules: [
      {
        test: /\.scss$/,
        use: [
          "style-loader",
          "css-loader",
          // {
          //   loader: "typings-for-css-modules-loader",
          //   options: {
          //     modules: true,
          //     importLoaders: 1,
          //     localIdentName: "[name]__[local]__[hash:base64:5]",
          //     namedExport: true,
          //     camelCase: true,
          //   },
          // },
          "sass-loader",
        ],
      },
    ],
  },
  plugins: [
    new webpack.HotModuleReplacementPlugin(),
  ],
});

export default config;
