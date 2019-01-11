import path from "path";
import webpack from "webpack";
import webpackMerge from "webpack-merge";

import common from "./webpack.config.common";

const config: webpack.Configuration = webpackMerge(common, {
  mode: "production",
  output: {
    path: path.resolve("./dist"),
    filename: "[name].[hash].js",
  },
  optimization: {
    splitChunks: {
      cacheGroups: {
        vendor: {
          test: /[\\/]node_modules[\\/]/,
          name: "vendor",
          chunks: "all",
        },
      },
    },
    runtimeChunk: "single",
  },
  plugins: [
    new webpack.NamedModulesPlugin(),
    new webpack.HashedModuleIdsPlugin(),
  ],
});

export default config;
