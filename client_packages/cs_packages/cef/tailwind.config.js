/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./*.{html,js}", "./components/*.{html,js}"],
  theme: {
    extend: {},
  },
  plugins: [
  require('tailwind-scrollbar-hide')
  ],
}
