import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.List;
import java.util.ArrayList;
import java.time.format.DateTimeFormatter;  
import java.time.LocalDateTime;    

public class AoC {
	
	public static class Mapper {
		public Long a;
		public Long b;
		public Long c;
	}
    public static void main(String[] args) {
		
		DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss");  
		LocalDateTime now = LocalDateTime.now();  
		System.out.println(dtf.format(now));  
   
        List<Long> seeds = new ArrayList<Long>();
		
        List<Mapper> stos = new ArrayList<Mapper>();
        List<Mapper> stof = new ArrayList<Mapper>();
        List<Mapper> ftow = new ArrayList<Mapper>();
        List<Mapper> wtol = new ArrayList<Mapper>();
        List<Mapper> ltot = new ArrayList<Mapper>();
        List<Mapper> ttoh = new ArrayList<Mapper>();
        List<Mapper> htol = new ArrayList<Mapper>();

        //Path filePath = Paths.get("aoc5.txt");
		Path filePath = Paths.get("aoc5_2.txt");
		
        Charset charset = StandardCharsets.UTF_8;


	    try {
			long c = -1;
			List<String> lines = Files.readAllLines(filePath, charset);
			for(String line: lines) {
				if (line.length() == 0) {
					c++;
				} else {
					String[] splits = line.split("\\s");
					if (splits.length == 3) {
						if (c == 0) pump(splits, stos);
                        if (c == 1) pump(splits, stof);
                        if (c == 2) pump(splits, ftow);
                        if (c == 3) pump(splits, wtol);
                        if (c == 4) pump(splits, ltot);
                        if (c == 5) pump(splits, ttoh);
                        if (c == 6) pump(splits, htol);
					} else {
						if (c == -1) {
							String[] toks = line.split("\\s");
							for (int i = 1; i < toks.length; ++i) {
                                seeds.add(Long.parseLong(toks[i]));
                            }
						}
					}
				}

			}
			
			long lowest = Long.MAX_VALUE;

            for (int i = 0; i < seeds.size(); i+=2)
            {
                for (int j = 0; j < seeds.get(i+1); ++j) 
                {
                    long s = getValue(stos, seeds.get(i)+j);
                    long f = getValue(stof, s);
                    long w = getValue(ftow, f);
                    long l = getValue(wtol, w);
                    long t = getValue(ltot, l);
                    long h = getValue(ttoh, t);
                    long location = getValue(htol, h);
                    if (location < lowest)
                    {
                        lowest = location;
                    }
                    //Console.WriteLine(seeds[i] + " = " + s + " " + f + " " + w + " " + l + " " + t + " " + h + " " + location);
                }
            }
			
			System.out.printf("%d\n", lowest);
			
		} catch (IOException ex) {
            System.out.format("I/O error: %s%n", ex);
        }
		
		now = LocalDateTime.now();  
		System.out.println(dtf.format(now));  

    }
	
	public static Long getValue(List<Mapper> i, Long value) {
		for (int c = 0; c < i.size(); ++c){
			if (value >= i.get(c).b) {
				if (value <= i.get(c).b + i.get(c).c){
					return value - i.get(c).b + i.get(c).a;
				}
			}
		}

		return value;
	}
		
	public static void pump(String[] splits, List<Mapper> themap){
        Mapper m = new Mapper();   
		
        m.a = Long.parseLong(splits[0]);
        m.b = Long.parseLong(splits[1]);
        m.c = Long.parseLong(splits[2]);

        themap.add(m);
    }
}