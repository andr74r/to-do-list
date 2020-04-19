var path = require("path");

module.exports = {
    mode: 'development',
    entry: "./app/app.jsx",
    output:{
        path: path.resolve(__dirname, './bundles'),
        publicPath: '/bundles/',
        filename: "bundle.js"
    },
    module:{
        rules:[
            {
                test: /\.jsx?$/,
                exclude: /(node_modules)/,
                loader: "babel-loader",
                options:{
                    presets:["@babel/preset-env", "@babel/preset-react"]
                }
            },
            {
                test: /\.css$/i,
                use: ['style-loader', 'css-loader'],
            }
        ]
    },
	devServer: {
		historyApiFallback: true,
	},
    resolve: {
        extensions: ['.js', '.jsx', '.css']
    }
}