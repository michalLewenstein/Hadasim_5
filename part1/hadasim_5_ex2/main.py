import java.io.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Main {

    public static List<File> splitTxtFile(File file, Map<Integer, Integer> numErrors) throws IOException {
        int lineSize = 100000;
        int lineNum = 0;
        List<File> files = new ArrayList<>();
        int partNumber = 1;
        String fileName = file.getName();
        StringBuilder currentContent = new StringBuilder();


        try (BufferedReader br = new BufferedReader(new FileReader(file))) {
            String line;
            while ((line = br.readLine()) != null) {
                currentContent.append(line).append("\n");
                lineNum++;

                if(lineNum == lineSize) {
                    String partFileName = String.format("%s.%d", fileName, partNumber++);
                    File partFile = new File(file.getParent(), partFileName);

                    try(FileWriter fw = new FileWriter(partFile)) {
                        fw.write(currentContent.toString());
                    }
                    files.add(partFile);
                    Map<Integer, Integer> partErrors = new HashMap<>();
                    findErrors(partErrors, partFile);
                    mergeErrors(numErrors,partErrors);

                currentContent.setLength(0);
                lineNum = 0;
            } }
        }
        if (currentContent.length() > 0) {
            String partFileName = String.format("%s.%d", fileName, partNumber++);
            File partFile = new File(file.getParent(), partFileName);

            try (FileWriter fw = new FileWriter(partFile)) {
                fw.write(currentContent.toString());
            }
            files.add(partFile);
            Map<Integer, Integer> partErrors = new HashMap<>();
            findErrors(partErrors, partFile);
            mergeErrors(numErrors, partErrors);
        }
    return files;
}


    public static void findErrors(Map<Integer, Integer> numErrors, File partFile) {
        try(BufferedReader bis = new BufferedReader(new FileReader(partFile))){
            String line;
            while ((line = bis.readLine())!=null){
                int start = line.lastIndexOf("_");
                int end = line.lastIndexOf('"');
                if (start != -1 && end != -1 && start < end){
                    try{
                        int error = Integer.parseInt(line.substring(start + 1, end));
                        numErrors.put(error, numErrors.getOrDefault(error, 0) + 1);
                    }catch (NumberFormatException e){
                        System.out.println("Error parsing " + line);
                    }
                }
                else{
                    System.out.println("cannot find error in line : "+ line);
                }
            }
        }
        catch (IOException e){
            e.printStackTrace();
        }
    }

    public static void mergeErrors(Map<Integer, Integer> numErrors, Map<Integer, Integer> partErrors) {
        // מעבר על כל האיברים במילון partErrors
        for (Map.Entry<Integer, Integer> entry : partErrors.entrySet()) {
            // אם המפתח כבר קיים ב numErrors, נוסיף את הערך של partErrors למתאים
            numErrors.put(entry.getKey(), numErrors.getOrDefault(entry.getKey(), 0) + entry.getValue());
        }
    }
    public static void main(String[] args) {
        try {
            File file = new File("C:\\Users\\user1\\Desktop\\Hadasim5\\part1\\files\\logs.txt.txt");

            Map<Integer, Integer> numErrors = new HashMap<>();
            List<File> splitFiles = splitTxtFile(file, numErrors);

            for (File f : splitFiles) {
                System.out.println("Created file: " + f.getAbsolutePath());
            }
             int nErrors = 5;

            List<Map.Entry<Integer, Integer>> topEntries = numErrors.entrySet()
                    .stream()
                    .sorted(Map.Entry.<Integer, Integer>comparingByValue().reversed())
                    .limit(nErrors)
                    .collect(Collectors.toList());

            System.out.println("הדפסת השגיאות");
            for (Map.Entry<Integer, Integer> error : topEntries) {
                System.out.println("error: " + error.getKey() + " times: " + error.getValue());
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}