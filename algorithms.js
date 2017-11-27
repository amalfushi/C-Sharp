//11.27 insertion sort
function insertionSort(arr){
    let temp = arr[0]
    for(i=1; arr.length-1; i++){
        if(arr[i]>temp){
            let x = i
            while(arr[x]>temp){
                arr[x] = arr[x-1];
                x--;
            }
            arr[x] = temp;
        }
    }
    return arr;
}

array = [10,9,-1,77,13];
console.log(array)
console.log(insertionSort(array));