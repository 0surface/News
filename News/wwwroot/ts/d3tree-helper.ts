/// <reference path="typings/d3.v3.4.5.d.ts" />
module D3treeHelper {
    declare var d3;

    export class D3Tree {
        treeData: Array<Object> = [
            {
                "name": "Website",
                "parent": "null",
                "children": []
            }
        ];
        tree : any;
        diagonal   : any;
        svg  : any;
        i = 0;
        duration = 750;
        root: any;
        frameElement: any;
       

        marigin = { top: 20, right: 120, bottom: 20, left: 120 };
        width = 960 - this.marigin.right - this.marigin.left;
        height = 500 - this.marigin.top - this.marigin.bottom;

        constructor(treeData: Array<Object>,
            tree: any,
            diagonal: any,
            svg: any,
            i: number,
            duration: number,
            root: any,    
            frameElement : Object,
            width: number,
            height: number
           )
        {
            this.treeData = treeData;
            this.tree = tree;
            this.diagonal = diagonal;
            this.svg = svg;
            this.i = i;
            this.duration = duration;
            this.root = root;
            this.frameElement = frameElement;
            this.width = width;
            this.height = height;
        }

       generateTreeDiagram(treeData : Object) {

        var self = this;
          
        self.marigin = { top: 20, right: 120, bottom: 20, left: 120 },
        self.width = 960 - self.marigin.right - self.marigin.left,
        self.height = 500 - self.marigin.top - self.marigin.bottom;


        self.tree = d3.layout.tree()
            .size([self.height, self.width]);

        self.diagonal = d3.svg.diagonal()
            .projection(function (d) { return [d.y, d.x]; });

        self.svg = d3.select(".treeArea").append("svg")
            .attr("width", self.width + self.marigin.right + self.marigin.left)
            .attr("height", self.height + self.marigin.top + self.marigin.bottom)
            .append("g")
            .attr("transform", "translate(" + self.marigin.left + "," + self.marigin.top + ")");

           self.root = self.treeData[0];
           self.root.x0 = self.height / 2;
           self.root.y0 = 0;

        this.update(self.root);

        d3.select(self.frameElement).style("height", "500px");
        }

       update(source) {
            var self = this;

        // Compute the new tree layout.
            var nodes = self.tree.nodes(self.root).reverse(),
            links = self.tree.links(nodes);

        // Normalize for fixed-depth.
        nodes.forEach(function (d) { d.y = d.depth * 180; });

        // Update the nodes…
        var node = self.svg.selectAll("g.node")
            .data(nodes, function (d) { return d.id || (d.id = ++self.i); });

        // Enter any new nodes at the parent's previous position.
        var nodeEnter = node.enter().append("g")
            .attr("class", "node")
            .attr("transform", function (d) { return "translate(" + source.y0 + "," + source.x0 + ")"; })
            .on("click", this.click);

        nodeEnter.append("circle")
            .attr("r", 1e-6)
            .style("fill", function (d) { return d._children ? "lightsteelblue" : "#fff"; });

        nodeEnter.append("text")
            .attr("x", function (d) { return d.children || d._children ? -13 : 13; })
            .attr("dy", ".35em")
            .attr("text-anchor", function (d) { return d.children || d._children ? "end" : "start"; })
            .text(function (d) { return d.name; })
            .style("fill-opacity", 1e-6);

        // Transition nodes to their new position.
        var nodeUpdate = node.transition()
            .duration(self.duration)
            .attr("transform", function (d) { return "translate(" + d.y + "," + d.x + ")"; });

        nodeUpdate.select("circle")
            .attr("r", 10)
            .style("fill", function (d) { return d._children ? "lightsteelblue" : "#fff"; });

        nodeUpdate.select("text")
            .style("fill-opacity", 1);

        // Transition exiting nodes to the parent's new position.
        var nodeExit = node.exit().transition()
            .duration(self.duration)
            .attr("transform", function (d) { return "translate(" + source.y + "," + source.x + ")"; })
            .remove();

        nodeExit.select("circle")
            .attr("r", 1e-6);

        nodeExit.select("text")
            .style("fill-opacity", 1e-6);

        // Update the links…
        var link = self.svg.selectAll("path.link")
            .data(links, function (d) { return d.target.id; });

        // Enter any new links at the parent's previous position.
        link.enter().insert("path", "g")
            .attr("class", "link")
            .attr("d", function (d) {
                var o = { x: source.x0, y: source.y0 };
                return self.diagonal({ source: o, target: o });
            });

        // Transition links to their new position.
        link.transition()
            .duration(self.duration)
            .attr("d", self.diagonal);

        // Transition exiting nodes to the parent's new position.
        link.exit().transition()
            .duration(self.duration)
            .attr("d", function (d) {
                var o = { x: source.x, y: source.y };
                return self.diagonal({ source: o, target: o });
            })
            .remove();

        // Stash the old positions for transition.
        nodes.forEach(function (d) {
            d.x0 = d.x;
            d.y0 = d.y;
        });
        }

       click(d) {
            if (d.children) {
                d._children = d.children;
                d.children = null;
            } else {
                d.children = d._children;
                d._children = null;
            }
            this.update(d);
        }
    }
    export class Test {
        testLog() {
            console.log("test");
        }
    }
}