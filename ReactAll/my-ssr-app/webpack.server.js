const path = require('path');
const nodeExternals = require('webpack-node-externals');

module.exports = {
  entry: './server/index.js',

  target: 'node',

  externals: [nodeExternals()],

  output: {
    path: path.resolve('server-build'),
    filename: 'index.js'
  


  module: {
    rules: [
      {
        {
		test: /.jsx$/ , loader:'babel-loader', exclude: '/node_modules/'}
        use: 'babel-loader'
      }
    ]
  }
};
