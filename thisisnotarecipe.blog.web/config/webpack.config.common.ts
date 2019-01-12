import path from "path";
import webpack from "webpack";

import CleanWebpackPlugin from "clean-webpack-plugin";
import HtmlWebpackPlugin from "html-webpack-plugin";

const config: webpack.Configuration = {
  entry: {
    app: "./src/index.tsx",
  },
  resolve: {
    extensions: [ ".tsx", ".ts", ".jsx", ".js" ],
  },
  output: {
    path: path.resolve("./dist"),
    filename: "[name].js",
    publicPath: "/",
  },
  module: {
    rules: [
      {
        test: /\.(ts|tsx)$/,
        use: {
          loader: "ts-loader",
          options: {
            transpileOnly: true,
          },
        },
      },
      {
        test: /\.(png|svg|jpg|jpeg|gif|ico)$/,
        use: "file-loader",
      },
      {
        test: /\.(woff|woff2|eot|ttf|otf)$/,
        use: "file-loader",
      },
      {
        test: /\.scss$/,
        use: [
          "style-loader",
          "css-loader",
          {
            loader: "postcss-loader",
            options: {
              plugins: [
                require("autoprefixer"),
              ],
            },
          },
          "sass-loader",
        ],
      },
    ],
  },
  plugins: [
    new CleanWebpackPlugin([ "dist" ], {
      root: path.resolve(__dirname, ".."),
    }),
    new HtmlWebpackPlugin({
      template: "./src/index.html",
    }),
  ],
};

export default config;
