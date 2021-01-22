import { Province } from "./models.ts";
// import { Lazy } from 'https://deno.land/x/lazy@v1.7.1/mod.ts';
export class Main {

    provinces = [] as Province[];
    public async run(): Promise<void> {
        // 读取文件
        const content = await Deno.readTextFile('./citys.json');
        this.provinces = JSON.parse(content);

        // 查询一共有多少个市区
        var count = this.provinces
            .flatMap((val) => val.city)
            .flatMap((v) => v.area).length;
        // 根据市数量排序
        this.provinces = this.provinces.sort((a, b) => a.city.length - b.city.length);

        // 分组 区/市/县
        var areas = this.provinces
            .flatMap((val) => val.city)
            .flatMap((v) => v.area);


        // 搜索某个区县的路径
        

        console.log('finish');

    }
}


const main = new Main();
main.run();
