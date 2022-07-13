/*
 * cef Vue app component, main variables here 
 */

const { createApp } = Vue
const app = createApp({
    data() {
        return {
            message: 'Hello Vue',
            count: 0,
        }
    },
    methods: {
        setMsg(){
            this.message = 'Hello World'
        }
    },  
}).mount('#app')