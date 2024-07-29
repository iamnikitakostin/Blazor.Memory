/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./**/*.{razor, html}"],
  theme: {
    extend: {
      screens: {
        "lg": "700px",
        "xs": "200px",
      }
    },
  },
  plugins: [],
}

