/*
 * cef Vue app component, main variables here 
 */

const { createApp } = Vue
//import ChatBox  from "./components/ChatBox"

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
    components: {
    }  
}).mount('#app')


